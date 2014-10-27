    Shader "custom/ParticlesAlphaBlended" {
Properties {
_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
_MainTex ("Particle Texture", 2D) = "white" {}
_QOffset ("Offset", Vector) = (0,0,0,0)
_Dist ("Distance", Float) = 100.0
_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
}

Category {
Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
Blend SrcAlpha One
AlphaTest Greater .01
ColorMask RGB
Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }

SubShader {
    Pass {

        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #pragma multi_compile_particles

        #include "UnityCG.cginc"

        sampler2D _MainTex;
        fixed4 _TintColor;
        float4 _QOffset;
        float _Dist;






        struct appdata_t {
            float4 vertex : POSITION;
            fixed4 color : COLOR;
            float4 texcoord : TEXCOORD0;
        };

        struct v2f {
            float4 vertex : POSITION;
//            float4 pos : SV_POSITION;

            fixed4 color : COLOR;
            float4 texcoord : TEXCOORD0;
            #ifdef SOFTPARTICLES_ON
            float4 projPos : TEXCOORD1;
            
            
           // float4 uv : TEXCOORD0;
            
            #endif
        };

        float4 _MainTex_ST;

        v2f vert (appdata_t v)
        {
            v2f o;
            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
            #ifdef SOFTPARTICLES_ON
            o.projPos = ComputeScreenPos (o.vertex);
            COMPUTE_EYEDEPTH(o.projPos.z);
            #endif
            o.color = v.color;
  //          o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
        
        
float4 vPos = mul (UNITY_MATRIX_MV, v.vertex);
float zOff = vPos.z/_Dist;
vPos += _QOffset*zOff*zOff;
o.vertex = mul (UNITY_MATRIX_P, vPos);
 
 o.texcoord = mul( UNITY_MATRIX_TEXTURE0, v.texcoord );
            
            return o;
        }

        sampler2D _CameraDepthTexture;
        float _InvFade;



       half4 frag (v2f i) : COLOR
{
half4 col = tex2D(_MainTex, i.texcoord.xy);
return col;
}
        ENDCG 
    }
}   
}
}
