Shader "LearningShaders/Water_Toon"
{
    Properties
    {
        _Metallic ("Metalic", Range(-1,1)) = 0
        _Gloss ("Gloss", Range(-1,1)) = 0
        _MainColor ("Main color", Color) = (1,1,1,1)
        [HideInInspector] _EmissionColor ("Emission Color", Color) = (0,0,0)

        _RippleSpeed ("Ripple speed", float) = 0.75
        [HDR]_RippleColor ("Ripple color", color) = (1,1,1,1)
        _RippleScale ("Ripple scale", float) = 3
        _RippleDisolve ("Ripple disolve", float) = 5

        _NormalStrenght ("Normal strenght", float) = 5

        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        float _Metallic;
        float _Gloss;
        fixed4 _MainColor;
        float _EmissionColor;

        float _RippleSpeed;
        fixed4 _RippleColor;
        float _RippleScale;
        float _RippleDisolve;

        float _NormalStrenght;

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float4 screenPos;
        };

        float Time_Time;
        float Time_SineTime;
        float Time_CosineTime;
        float Time_DeltaTime;
        float Time_SmoothDelta;

        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float3 TransformWorldToTangent(float3 dirWS, float3x3 worldToTangent)
        {
            return mul(worldToTangent, dirWS);
        }

        inline float2 NoiseRandomVector (float2 UV, float offset)
        {
            float2x2 m = float2x2(15.27, 47.63, 99.41, 89.98);
            UV = frac(sin(mul(UV, m)) * 46839.32);
            return float2(sin(UV.y*+offset)*0.5+0.5, cos(UV.x*offset)*0.5+0.5);
        }

        void InitTime()
        {
            Time_Time = _Time.y;
            Time_SineTime = _SinTime.w;
            Time_CosineTime = _CosTime.w;
            Time_DeltaTime = unity_DeltaTime.x;
            Time_SmoothDelta = unity_DeltaTime.z;
        }

        void Multiply(float4 A, float4 B, out float4 Out)
        {
            Out = A * B;
        }
        void Multiply(float4 A, float4 B, out float Out)
        {
            Out = A * B;
        }

        void Multiply(float3 A, float3 B, out float3 Out)
        {
            Out = A * B;
        }

        void Voronoi(float2 UV, float AngleOffset, float CellDensity, out float Out, out float Cells)
        {
            float2 g = floor(UV * CellDensity);
            float2 f = frac(UV * CellDensity);
            float t = 8.0;
            float3 res = float3(8.0, 0.0, 0.0);

            for(int y=-1; y<=1; y++)
            {
                for(int x=-1; x<=1; x++)
                {
                    float2 lattice = float2(x,y);
                    float2 offset = NoiseRandomVector(lattice + g, AngleOffset);
                    float d = distance(lattice + offset, f);
                    if(d < res.x)
                    {
                        res = float3(d, offset.x, offset.y);
                        Out = res.x;
                        Cells = res.y;
                    }
                }
            }
        }

        void RadialShear(float2 UV, float2 Center, float Strength, float2 Offset, out float2 Out)
        {
            float2 delta = UV - Center;
            float delta2 = dot(delta.xy, delta.xy);
            float2 delta_offset = delta2 * Strength;
            Out = UV + float2(delta.y, -delta.x) * delta_offset + Offset;
        }

        void Power(float A, float B, out float Out)
        {
            Out = pow(A, B);
        }

        void NormalFromHeight_Tangent(float In, float Strength, float3 Position, float3x3 TangentMatrix, out float3 Out)
        {
            float3 worldDerivativeX = ddx(Position);
            float3 worldDerivativeY = ddy(Position);

            float3 crossX = cross(TangentMatrix[2].xyz, worldDerivativeX);
            float3 crossY = cross(worldDerivativeY, TangentMatrix[2].xyz);
            float d = dot(worldDerivativeX, crossY);
            float sgn = d < 0.0 ? (-1.f) : 1.f;
            float surface = sgn / max(0.00000000000001192093f, abs(d));

            float dHdx = ddx(In);
            float dHdy = ddy(In);
            float3 surfGrad = surface * (dHdx*crossY + dHdy*crossX);
            Out = normalize(TangentMatrix[2].xyz - (Strength * surfGrad));
            Out = TransformWorldToTangent(Out, TangentMatrix);
        }
        void NormalStrength(float3 In, float Strength, out float3 Out)
        {
            Out = (In.rg * Strength, lerp(1, In.b, saturate(Strength)));
        }

        inline float NoiseRandomValue (float2 uv)
        {
            return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453);
        }

        inline float NoiseInterpolate (float a, float b, float t)
        {
            return (1.0-t)*a + (t*b);
        }

        inline float ValueNoise (float2 uv)
        {
            float2 i = floor(uv);
            float2 f = frac(uv);
            f = f * f * (3.0 - 2.0 * f);

            uv = abs(frac(uv) - 0.5);
            float2 c0 = i + float2(0.0, 0.0);
            float2 c1 = i + float2(1.0, 0.0);
            float2 c2 = i + float2(0.0, 1.0);
            float2 c3 = i + float2(1.0, 1.0);
            float r0 = NoiseRandomValue(c0);
            float r1 = NoiseRandomValue(c1);
            float r2 = NoiseRandomValue(c2);
            float r3 = NoiseRandomValue(c3);

            float bottomOfGrid = NoiseInterpolate(r0, r1, f.x);
            float topOfGrid = NoiseInterpolate(r2, r3, f.x);
            float t = NoiseInterpolate(bottomOfGrid, topOfGrid, f.y);
            return t;
        }

        void SimpleNoise(float2 UV, float Scale, out float Out)
        {
            float t = 0.0;

            float freq = pow(2.0, float(0));
            float amp = pow(0.5, float(3-0));
            t += ValueNoise(float2(UV.x*Scale/freq, UV.y*Scale/freq))*amp;

            freq = pow(2.0, float(1));
            amp = pow(0.5, float(3-1));
            t += ValueNoise(float2(UV.x*Scale/freq, UV.y*Scale/freq))*amp;

            freq = pow(2.0, float(2));
            amp = pow(0.5, float(3-2));
            t += ValueNoise(float2(UV.x*Scale/freq, UV.y*Scale/freq))*amp;

            Out = t;
        }

        void NormalBlend(float3 A, float3 B, out float3 Out)
        {
            Out = normalize(float3(A.rg + B.rg, A.b * B.b));
        }
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 mainUV = IN.uv_MainTex;
            
            float AngleOffset;
            float Cells;

            InitTime();
            Multiply(Time_Time, _RippleSpeed, AngleOffset);

            
            RadialShear(mainUV, float2(0.5,0.5), float(1), float2(0,0), mainUV);
            float VoronoiOut;
            float VoronoiCells;
            Voronoi(mainUV, AngleOffset, _RippleScale, _EmissionColor, VoronoiCells);
            
            Power(_EmissionColor, _RippleDisolve, _EmissionColor);
            
            float4 multiplyOut;
            Multiply(_EmissionColor, _RippleColor, multiplyOut);
            
            float3 normal1;
            float3 normal2;
            NormalFromHeight_Tangent(multiplyOut, float(1), IN.screenPos, float3x3(1,1,1,1,1,1,1,1,1), normal1);
            NormalStrength(normal1, _NormalStrenght, normal1);

            float2 noise = float2(1,1);
            SimpleNoise(noise, float(20), noise[0]);
            NormalFromHeight_Tangent(noise, float(1), IN.screenPos, float3x3(1,1,1,1,1,1,1,1,1), normal2);
            NormalStrength(normal2, _NormalStrenght, normal2);
            Multiply(normal1, normal2, normal1);

            
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _MainColor;
            o.Albedo = c.rgb;
            o.Emission = c.rgb * multiplyOut;
            o.Metallic = _Metallic;
            o.Smoothness =_Gloss;
            o.Normal = normal1;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
