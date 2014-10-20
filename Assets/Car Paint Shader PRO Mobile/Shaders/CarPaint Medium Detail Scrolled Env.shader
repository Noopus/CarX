Shader "RedDotGames/Mobile/Scrolled Environment/Car Paint Medium Detail" {
   Properties {
   
	  _Color ("Diffuse Material Color (RGB)", Color) = (1,1,1,1) 
	  _SpecColor ("Specular Material Color (RGB)", Color) = (1,1,1,1) 
	  _Shininess ("Shininess", Range (0.01, 10)) = 1
	  _Gloss ("Gloss", Range (0.0, 10)) = 1
	  _MainTex ("Diffuse Texture", 2D) = "white" {} 
	  _EnvSide ("Env Side Texture", 2D) = "black" {} 
	  _EnvTop ("Env Top Texture", 2D) = "black" {} 
	  //_EnvInt ("Env Intensity", float) = 1
	  _EnvTimer ("Env Timer", float) = 1
	  
	  _Cube("Reflection Map", Cube) = "" {}
	  _Reflection("Reflection Power", Range (0.00, 1)) = 0
	  _FrezPow("Fresnel Power",Range(0,2)) = .25
	  _FrezFalloff("Fresnal Falloff",Range(0,10)) = 4	  
  
   }
SubShader {
   Tags { "QUEUE"="Geometry" "RenderType"="Opaque" " IgnoreProjector"="True"}	  
      Pass {  
      
         Tags { "LightMode" = "ForwardBase" } // pass for 
            // 4 vertex lights, ambient light & first pixel light
 
         CGPROGRAM
         #pragma fragmentoption ARB_precision_hint_fastest
         #pragma multi_compile_fwdbase 
         #pragma vertex vert
         #pragma fragment frag
		 #pragma target 2.0	
		 #pragma exclude_renderers d3d11 xbox360 ps3 d3d11_9x flash
		 //#include "AutoLight.cginc"
 		 #include "UnityCG.cginc"
 
         // User-specified properties
		 uniform sampler2D _MainTex; 
		 uniform sampler2D _EnvSide;
		 uniform sampler2D _EnvTop;
         //uniform sampler2D _BumpMap; 
	 
		 
         //uniform fixed4 _BumpMap_ST;		 
         uniform fixed4 _Color; 
		 uniform fixed _Reflection;
         uniform fixed4 _SpecColor; 
         uniform half _Shininess;
		 uniform half _Gloss;
		 uniform float _EnvTimer;
		// uniform fixed _EnvInt;
		 
		 uniform fixed4 _EnvSide_ST;		 
		 uniform fixed4 _EnvTop_ST;		 
		 
		 //uniform fixed normalPerturbation;
		 
		 //uniform fixed4 _paintColor0; 
		 //uniform fixed4 _paintColorMid; 
		 uniform fixed4 _paintColor2;
		 
		 uniform samplerCUBE _Cube; 
		 fixed _FrezPow;
		 half _FrezFalloff;
		 
 
         // The following built-in uniforms (except _LightColor0) 
         // are also defined in "UnityCG.cginc", 
         // i.e. one could #include "UnityCG.cginc" 
         uniform fixed4 _LightColor0; 
            // color of light source (from "Lighting.cginc")
 
         struct vertexInput {
            float4 vertex : POSITION;
            fixed3 normal : NORMAL;
			half4 texcoord : TEXCOORD0;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float4 posWorld : TEXCOORD0;
            fixed3 normalDir : TEXCOORD1;
			fixed3 vertexLighting : TEXCOORD2;
			half2 tex : TEXCOORD3;
			fixed3 viewDir : TEXCOORD4;
			fixed4 envCoord : TEXCOORD5;
			fixed3 blend_weights : TEXCOORD6;
			half2 tex1 : TEXCOORD7;
         };
 
         vertexOutput vert(vertexInput input)
         {          
            vertexOutput o;
 
            o.posWorld = mul(_Object2World, input.vertex);
            o.normalDir = normalize(fixed3(mul(fixed4(input.normal, 0.0), _World2Object)));
			   
			o.tex = input.texcoord;
            o.pos = mul(UNITY_MATRIX_MVP, input.vertex);
            o.viewDir = normalize(fixed3(mul(_Object2World, input.vertex) - fixed4(_WorldSpaceCameraPos, 1.0)));
  
  			//scrolling
			float3 blend_weights = abs(input.normal.xyz);
            blend_weights = blend_weights - 0.2679f;
			blend_weights = max(blend_weights, 0);
			blend_weights /= (blend_weights.x + blend_weights.y + blend_weights.z).xxx;
			
			o.blend_weights = blend_weights;
			o.envCoord.xy = input.vertex.zy + float2(_EnvTimer,0);
			o.envCoord.xy = o.envCoord.xy * _EnvSide_ST.xy + _EnvSide_ST.zw;
			
			//o.envCoord.xy = mul(UNITY_MATRIX_TEXTURE2,(input.vertex.zy * _TexScale + _EnvTimer).xyxy );
			
			//o.envCoord.zw = input.vertex.zx * _TexScale + float2(_Time.y,0) * _EnvTimer;
			//o.envCoord.zw = mul(UNITY_MATRIX_TEXTURE3,(input.vertex.zx * _TexScale + _EnvTimer).xyxy );
			
			o.envCoord.zw = input.vertex.zx + float2(_EnvTimer,0);
			o.envCoord.zw = o.envCoord.zw * _EnvTop_ST.xy + _EnvTop_ST.zw;
			
			//end scrolling
  
			   
            // Diffuse reflection by four "vertex lights"            
            o.vertexLighting = fixed3(0.0, 0.0, 0.0);
            #ifdef VERTEXLIGHT_ON
            for (int index = 0; index < 2; index++)
            {    
               fixed4 lightPosition = fixed4(unity_4LightPosX0[index], 
                  unity_4LightPosY0[index], 
                  unity_4LightPosZ0[index], 1.0);
                  
               fixed3 vertexToLightSource = 
                  fixed3(lightPosition - o.posWorld);        
               fixed3 lightDirection = normalize(vertexToLightSource);
               
               fixed squaredDistance = 
                  dot(vertexToLightSource, vertexToLightSource);
               fixed attenuation = 1.0 / (1.0 + 
                  unity_4LightAtten0[index] * squaredDistance);
                  
               fixed3 diffuseReflection =  
                  attenuation * fixed3(unity_LightColor[index]) 
                  * fixed3(_Color) * max(0.0, 
                  dot(o.normalDir, lightDirection));         
 
               o.vertexLighting = 
                  o.vertexLighting + diffuseReflection;
            }
            #endif
            
            //TRANSFER_VERTEX_TO_FRAGMENT(o);			   
            return o;
         }
 
         fixed4 frag(vertexOutput input) : COLOR
         {
		 
		 
		    //fixed4 encodedNormal = tex2D(_BumpMap, _BumpMap_ST.xy * input.tex.xy + _BumpMap_ST.zw);
		 
            fixed3 normalDirection = normalize(input.normalDir); 
            fixed3 viewDirection = normalize(
               _WorldSpaceCameraPos - input.posWorld.xyz);
            fixed3 lightDirection;
            fixed attenuation;
 
			fixed4 textureColor = tex2D(_MainTex, fixed2(input.tex));
 
            if (0.0 == _WorldSpaceLightPos0.w) // directional light?
            {
               attenuation = 1.0; // no attenuation
               lightDirection = 
                  normalize(fixed3(_WorldSpaceLightPos0));
            } 
            else // point or spot light
            {
               fixed3 vertexToLightSource = 
                  fixed3(_WorldSpaceLightPos0 - input.posWorld);
               fixed distance = length(vertexToLightSource);
               attenuation = 1.0 / distance; // linear attenuation 
               lightDirection = normalize(vertexToLightSource);
            }
 
			//attenuation = LIGHT_ATTENUATION(input);
 
            fixed3 ambientLighting = 
                fixed3(UNITY_LIGHTMODEL_AMBIENT) * fixed3(_Color);
 
            fixed3 diffuseReflection = 
               attenuation * fixed3(_LightColor0) * fixed3(_Color) 
               * max(0.0, dot(normalDirection, lightDirection));
 
               fixed3 halfwayDirection = 
                  normalize(lightDirection + viewDirection);
				  
            fixed3 halfwayVector = 
               normalize(lightDirection + input.viewDir);				  
				  
			fixed dotLN = dot(lightDirection, input.normalDir); 				  
				  
               //fixed w = pow(1.0 - max(0.0, 
                 // dot(halfwayDirection, viewDirection)), 5.0);

            fixed3 specularReflection;
			//fixed3 metalicReflection;
			
			if (dot(normalDirection, lightDirection) < 0.0) 
            //if (dotLN) < 0.0) 
               // light source on the wrong side?
            {
               specularReflection = fixed3(0.0, 0.0, 0.0); 
                  // no specular reflection
			   //metalicReflection = fixed3(0.0, 0.0, 0.0); 
            }
            else // light source on the right side
            {
               specularReflection = attenuation * fixed3(_LightColor0) 
                  * fixed3(_SpecColor) * pow(max(0.0, dot(
                  reflect(-lightDirection, normalDirection), 
                  viewDirection)), _Shininess);
            }
			specularReflection *= _Gloss;

			fixed3 reflectedDir = reflect(input.viewDir, normalize(input.normalDir) );
            fixed4 reflTex = texCUBE(_Cube, reflectedDir);
			
			//Calculate Reflection vector
			fixed SurfAngle= clamp(abs(dot (reflectedDir,input.normalDir)),0,1);
			fixed frez = pow(1-SurfAngle,_FrezFalloff) ;
			frez*=_FrezPow;
			
			_Reflection += frez;			
			
			reflTex.rgb *= saturate(_Reflection);
			 
            fixed4 col1 = tex2D(_EnvSide, input.envCoord.xy);
            fixed4 col2 = tex2D(_EnvTop, input.envCoord.zw);			 
			fixed4 blended_color = col1.rgba * input.blend_weights.xxxx + col2.rgba * input.blend_weights.yyyy; 
			 
			fixed4 color = fixed4(textureColor.rgb * saturate(input.vertexLighting + ambientLighting + diffuseReflection) + specularReflection, 1.0);
			color += reflTex;
			color += frez * reflTex;
			color += blended_color.rgba;
			
            return color;
			
			
			
         }
         ENDCG
      }
 }
   // The definition of a fallback shader should be commented out 
   // during development:
   Fallback "Mobile/Diffuse"
}