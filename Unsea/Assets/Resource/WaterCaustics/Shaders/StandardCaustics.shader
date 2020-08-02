Shader "Custom/StandardCaustics" {
	Properties {
		[Header(Surface Shader Properties)]
		_MainColor ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpMap ("Bumpmap", 2D) = "bump" {}
		_Smoothness ("Smoothness", Range(0,1)) = 0.2
		_Metallic ("Metallic", Range(0,1)) = 0.2
		[Header(Caustic Color Properties)]
		_Color ("Color and Alpha", Color) = (1,1,1,1)
		_Diffraction ("Diffraction", Range (0.0, 1.0)) = 0.05
		_Multiply ("Multiply", Range (1, 2)) = 1.5
		[Header(Caustic Textures)]
		_Blend ("Dual texture blend", Range (0, 1)) = 0.6
		[NoScaleOffset]
		_CausticsTex ("Albedo (RGB)", 2D) = "white" {}
		[NoScaleOffset]
		_NoiseTex ("Distortion Texture", 2D) = "black" { }
		_CausticTile ("Caustic Tiling", Float) = 5
		_NoiseTile ("Noise/Distortion Tiling", Float) = 0.5
		[Header(Movement)]
		_CausticSpeed("Caustic Speed", Float) = 5.0
		_DistortionSpeed ("Distortion Speed", Float) = 3.0
		[Header(Height)]
		_Height ("Water Height", Float) = 10.0
		_SmoothHeight ("Wet Height", Float) = 11.0
		_Wetness ("Wetness", Range(0,1)) = 0.8
		_WetRange ("Wetness Range", Float) = 2
		_EdgeBlend ("Edge Blend", Range (0.1, 100)) = 1.0
		_DepthBlend ("Depth Blur", Float) = 200.0
		_DepthFade ("Depth Fade", Float) = 10.0
		[Header(Distance)]
		_LOD ("LOD Amount", Float) = 100.0
		_Distance ("Distance Cutoff", Float) = 250.0
		_DistanceBlend ("Distance Blend", Float) = 100.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard vertex:vert fullforwardshadows
		#pragma target 5.0

		sampler2D _MainTex;
		sampler2D _BumpMap;
		sampler2D _CausticsTex;
		sampler2D _NoiseTex;

		float _CausticTile;
		float _NoiseTile;
		fixed4 _Color;
		fixed4 _MainColor;
		half _Diffraction;
		half _Multiply;
		half _Smoothness;
		half _Metallic;
		float _Height;
		float _SmoothHeight;
		float _Wetness;
		float _WetRange;
		float _Blend;
		float _DepthBlend;
		float _DepthFade;
		float _EdgeBlend;
		float _CausticSpeed;
		float _DistortionSpeed;
		float _LOD;
		float _Distance;
		float _DistanceBlend;
		
		struct Input {
			float3 pos;
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float2 uv_CausticsTex;
			float2 uv_NoiseTex;
			float3 worldPos;
			float3 worldNormal;
			INTERNAL_DATA // needed for worldNormal
		};
		
		void vert (inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input,o);
            o.pos = UnityObjectToClipPos (v.vertex);
			fixed3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
			float3 worldNormal = UnityObjectToWorldNormal(v.normal);
        }
		fixed4 triplanarUV(float3 blendNormal, float3 wpos)
		{					
			float2 finaluv = wpos.xy;
			float2 x = wpos.yz;
			float2 y = wpos.xz;
			finaluv = lerp(finaluv, x, blendNormal.x);
			finaluv = lerp(finaluv, y, blendNormal.y);
			finaluv *= 0.005; // added to preserve scaling values when upgrading from previous version.
			return half4(finaluv.x,finaluv.y,0,0);
		}
		void surf (Input IN, inout SurfaceOutputStandard o) {
			float3 blending = abs(IN.worldNormal);
			float3 blendNormal = normalize(max(blending, 0.00001));
			float b = (blendNormal.x + blendNormal.y + blendNormal.z);
			blendNormal/=blendNormal*2;
				
			// main surface texture
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _MainColor;
			
			// variables used for LOD
			float dist = distance(_WorldSpaceCameraPos, IN.worldPos);
			float distLOD = dist/_LOD;
			
			// noise/distortion texture
			fixed4 noise = tex2D(_NoiseTex, IN.worldPos.xz*0.01*_NoiseTile-frac(_Time.y*_DistortionSpeed*0.01));
			noise = noise + (_Time.y*_CausticSpeed*0.01);
			
			// height/blend properties
			float height = IN.worldPos.y-_Height;
			float heightBlend = height/-_DepthBlend;
			
			// variables used to reduce redundant calculations.
			float lodTotal = heightBlend*100+distLOD; // *100 used for easier input in the inspector.
			float2 uvTotal = triplanarUV(blendNormal,IN.worldPos)*_CausticTile;
			_Diffraction = _Diffraction*0.1;
			
			// Color A is first caustic texture, Color B is duplicated texture with opposite uv movement.
			// Color channels/uvs are offset to produce a Diffraction effect.
			fixed4 cA = tex2Dlod (_CausticsTex, float4(uvTotal+noise,0,lodTotal));
			fixed cAr = tex2Dlod (_CausticsTex, float4(uvTotal + frac(fixed2(_Diffraction, _Diffraction)+noise),0,lodTotal));
			fixed cAg = tex2Dlod (_CausticsTex, float4(uvTotal + frac(fixed2(_Diffraction, -_Diffraction)+noise),0,lodTotal));
			fixed cAb = tex2Dlod (_CausticsTex, float4(uvTotal + frac(fixed2(-_Diffraction, -_Diffraction)+noise),0,lodTotal));
			cA = fixed4(cAr, cAg, cAb,_Color.a); // final color A
			fixed4 cB = tex2Dlod (_CausticsTex, float4(uvTotal +noise,0,lodTotal));
			fixed cBr = tex2Dlod (_CausticsTex, float4(uvTotal - frac(fixed2(_Diffraction, _Diffraction)+noise),0,lodTotal));
			fixed cBg = tex2Dlod (_CausticsTex, float4(uvTotal - frac(fixed2(_Diffraction, -_Diffraction)+noise),0,lodTotal));
			fixed cBb = tex2Dlod (_CausticsTex, float4(uvTotal - frac(fixed2(-_Diffraction, -_Diffraction)+noise),0,lodTotal));
			cB = fixed4(cBr, cBg, cBb,_Color.a); // final color B
			
			// blend color A and B, and properties
			cA = lerp(cA,cB,_Blend)*_Color*_Multiply; 
			
			// blend caustics with main texture
			cA = lerp(cA,c,1.0-_Color.a); 
			
			// height blending
			if (IN.worldPos.y<=_Height) 
				cA.a = saturate(lerp(cA.a,1.0-_Color.a,heightBlend*_DepthFade));
			else 
				cA.a = saturate(lerp(cA.a,0.0,height/_EdgeBlend));
			
			// wetness blending
			float smoothed = _Smoothness;
			if (IN.worldPos.y>=_SmoothHeight) 
				smoothed = lerp(smoothed,_Wetness,(IN.worldPos.y-_SmoothHeight)/2);
			if (IN.worldPos.y>=_SmoothHeight-_WetRange) 
				smoothed = lerp(smoothed,_Smoothness,(IN.worldPos.y-_SmoothHeight-_WetRange)/2);
				
			// distance blending
			float distDiff = (dist-_Distance)/_DistanceBlend;
			if (dist>_Distance)
				cA = lerp(saturate(cA-distDiff),0,distDiff);
			
			cA = lerp(c,cA,cA.a);
				
			o.Albedo = saturate(cA);
			o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
			o.Metallic = _Metallic;
			o.Smoothness = saturate(smoothed);
			
		}
		ENDCG
	}
	FallBack "Diffuse"
}
