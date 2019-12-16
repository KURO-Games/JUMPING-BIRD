Shader "Art/Ripple" {
	Properties{
		_Speed("Speed", Range(-10, 10)) = 1
		_Color("Color", Color) = (0.3, 0.6, 0.7, 1)
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

				int _Speed;
				float4 _Color;

				// ピクセルシェーダー
				float4 frag(VertexOutput output) : SV_Target {
					float2 pos = float2(2 * (output.uv.x - 0.5), 2 * (output.uv.y - 0.5));
					float circle = sin(length(pos) * 70.0 - _Time * 90 * _Speed);
					return float4(1 - circle * (1 - _Color.r), 1 - circle * (1 - _Color.g), 1 - circle * (1 - _Color.b), _Color.a);
				}

				ENDCG
			}
	}
}