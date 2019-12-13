Shader "Art/Circle" {
	Properties{
		_Radius("Radius", Range(0, 1)) = 1
		_Width("Width", Range(0, 1)) = 0.1
		_Color("Color", Color) = (1,1,1,1)
	}
		SubShader{
			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				struct VertexInput {
					float4 pos:  POSITION;    // 3D座標
					float2 uv:   TEXCOORD0;   // テクスチャ座標
				};

				struct VertexOutput {
					float4 sv_pos:    SV_POSITION; // 2D座標
					float2 uv:   TEXCOORD0;   // テクスチャ座標
				};

				// 頂点シェーダー
				VertexOutput vert(VertexInput input) {
					VertexOutput output;
					output.sv_pos = UnityObjectToClipPos(input.pos);
					output.uv = input.uv;

					return output;
				}

				float _Radius;
				float _Width;
				float4 _Color;

				// ピクセルシェーダー
				float4 frag(VertexOutput output) : SV_Target {
					float2 pos = float2(2 * (output.uv.x - 0.5), 2 * (output.uv.y - 0.5));
					float len = length(pos);
					if (len > _Radius || len < (_Radius - _Width))
						discard;
					return _Color;
				}

				ENDCG
			}
	}
}