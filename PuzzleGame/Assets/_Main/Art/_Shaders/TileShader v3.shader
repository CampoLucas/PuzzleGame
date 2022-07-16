Shader "PuzzleSwap/TileShader v3"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Main Texture (RGB)", 2D) = "white" {}
        _NormalTex ("Normal Texture (RGB)", 2D) = "bump" {}
        
        [HDR] _LightColor("LightColor", Color) = (1,1,1,1)
        _Brightness("Brightness", Range(0,1)) = 0.3
        _Strength("Strength", Range(0,1)) = 0.5
        _Detail("Detail", Range(0,1)) = 0.3
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert
        #pragma target 3.0

        fixed4 _Color;
        sampler2D _MainTex;
        sampler2D _NormalTex;
        sampler2D _RampTex;


        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NormalTex;

        };

        float4 _LightColor;
        float _Brightness;
        float _Strength;
        float _Detail;


        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        // fixed4 LightingToon (SurfaceOutput s, fixed3 lightDir, fixed atten)
        // {
        //     half NdotL = dot(s.Normal, lightDir);
        //     NdotL = tex2D(_RampTex, fixed2(NdotL, 0.5));
        //     
        //     fixed4 c;
        //     c.rgb = s.Albedo * _LightColor0.rgb * NdotL * atten;
        //     c.a = s.Albedo;
        //     
        //     return c;
        // }
        float Toon(float3 normal, float3 lightDir)
        {
            float NdotL = max(0.0,dot(normalize(normal), normalize(lightDir)));

            return floor(NdotL/_Detail);
        }

        
        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            

            
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed3 n = UnpackNormal(tex2D(_NormalTex, IN.uv_NormalTex)).rgb;
            c *= Toon(n, _WorldSpaceLightPos0.xyz) * _Strength * _LightColor  + _Brightness;
            o.Normal = normalize(n);
            o.Albedo = c.rgb;
            o.Alpha = c.a ;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
