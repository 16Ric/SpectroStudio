Shader "Custom/GlowShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GlowColor ("Glow Color", Color) = (0, 1, 1, 1) 
        _GlowIntensity ("Glow Intensity", Range(0, 5)) = 0
        _PulseSpeed ("Pulse Speed", Range(0.1, 5)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 glowPosition : TEXCOORD1; // For glow effect
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _GlowColor;
            float _GlowIntensity;
            float _PulseSpeed;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                
                // Calculate the pulsing effect
                float pulse = sin(_Time.y * _PulseSpeed) * 0.5 + 0.5; // Range from 0 to 1
                o.glowPosition = float4(pulse * _GlowIntensity, pulse * _GlowIntensity, pulse * _GlowIntensity, 1.0);
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 tex = tex2D(_MainTex, i.uv);
                // Apply the glow effect based on the pulse calculation
                return tex + i.glowPosition * _GlowColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
