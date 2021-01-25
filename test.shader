  Shader "test" {
    Properties {
      _Amount ("Extrusion Amount", Range(-1,1)) = 0.5
      _Metallic ("Metallic", Range(0,1)) = 0.0
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert vertex:vert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
      };
      float _Amount;
      void vert (inout appdata_full v) {
          v.vertex.xyz += v.normal * _Amount * v.vertex.rgb.r;
      }
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Metallic = _Metallic;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }