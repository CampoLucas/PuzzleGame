Shader "_Shades/ToonShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _RampTex ("Ramp", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Toon
        #pragma target 3.0

        fixed4 _Color;
        sampler2D _MainTex;
        sampler2D _RampTex;

        struct Input
        {
            float2 uv_MainTex;
        };


        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        fixed4 LightingToon (SurfaceOutput s, fixed3 lightDir, fixed atten)
        {
            half NdotL = dot(s.Normal, lightDir);
            NdotL = tex2D(_RampTex, fixed2(NdotL, 0.5));

            fixed4 c;
            c.rgb = s.Albedo * _LightColor0.rgb * NdotL * atten;
            c.a = s.Albedo;

            return c;
        }
        
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            

            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
