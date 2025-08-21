Shader "Custom/GhostlyShadow"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // Ghost texture
        _Transparency ("Transparency", Range(0.1, 1)) = 0.5
        _FlickerSpeed ("Flicker Speed", Range(0.1, 5)) = 1.0
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // Enable transparency
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float _Transparency;
            float _FlickerSpeed;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample the ghost texture
                fixed4 col = tex2D(_MainTex, i.uv);

                // Add flicker effect using sine wave based on time
                float flicker = abs(sin(_Time.y * _FlickerSpeed));

                // Set transparency and apply flicker
                col.a *= _Transparency * flicker;

                return col;
            }
            ENDCG
        }
    }
    FallBack "Transparent/VertexLit"
}
