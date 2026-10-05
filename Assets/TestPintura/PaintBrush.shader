Shader "Unlit/PaintBrush"
{Properties{ _Size("Size", Float) = 0.02 _UV("UV", Vector) = (0,0,0,0) }
SubShader{
    Pass {
        HLSLPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        struct Attributes { float4 positionOS : POSITION; float2 uv : TEXCOORD0; };
        struct Varyings { float4 positionCS : SV_POSITION; float2 uv : TEXCOORD0; };
        float _Size; float4 _UV;

        Varyings vert(Attributes input) {
            Varyings output;
            output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
            output.uv = input.uv;
            return output;
        }

        half4 frag(Varyings input) : SV_Target {
            float d = distance(input.uv, _UV.xy);
            return (d < _Size) ? half4(0, 0, 0, 1) : half4(1, 1, 1, 1);
        }
        ENDHLSL
    }

}
}