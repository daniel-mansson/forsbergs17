Shader "Custom/Test" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_NoiseTex ("Noise (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_BurnAmount ("BurnAmount", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Transparent" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows



		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _NoiseTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		half _BurnAmount;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			float4 n1 = tex2D(_NoiseTex, IN.uv_MainTex + float2(_Time.x, _Time.x * 5.6)) * _Color;
			float4 n2 = tex2D(_NoiseTex, IN.uv_MainTex + float2(-0.2 * _Time.x, _Time.x * 3.2)) * _Color;
			float4 n3 = tex2D (_NoiseTex, IN.uv_MainTex + float2(0.43 * _Time.x, _Time.x * 10.2)) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = 1;

			float v = n1.r + n2.r + n3.r;
			v *= _BurnAmount;
			if (v > 1)
				discard;
			else if (v > 0.95)
				o.Emission = float3(1,0.5,0.1) * (1 + (v - 0.9) * 10);

		//	discard;
		}
		ENDCG
	}
	
	Fallback "Transparent/Cutout/Diffuse"
}
