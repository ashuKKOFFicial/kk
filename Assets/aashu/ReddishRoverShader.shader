Shader "Custom/ReddishRoverShader"
{
    Properties
    {
        _OutlineColor("Outline Color", Color) = (0,0,0,1)
        _Outline("Outline Width", Range(0.002, 0.03)) = 0.005
    }
        SubShader
    {
        Tags { "Queue" = "Overlay" "RenderType" = "Opaque" }
        Pass
        {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }
            Cull Front
            ZWrite On
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            float _Outline;
            fixed4 _OutlineColor; // Declaring _OutlineColor property

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag(v2f i) : COLOR
            {
                half4 col = _OutlineColor;
                return col;
            }
            ENDCG
        }
        Pass
        {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }
            Cull Back
            ZWrite On
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            float _Outline;
            fixed4 _OutlineColor; // Declaring _OutlineColor property

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag(v2f i) : COLOR
            {
                half4 col = _OutlineColor;
                return col;
            }
            ENDCG
        }
    }
}
