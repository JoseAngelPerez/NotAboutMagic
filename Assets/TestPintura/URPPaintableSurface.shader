Shader "Unlit/URPPaintableSurface"
{
    Properties
    {
        _MainTex("Base Map", 2D) = "white" {}
        _PaintMap("Paint Map", 2D) = "white" {}
        _BaseColor("Base Color", Color) = (1,1,1,1)
        _PaintColor("Paint Color", Color) = (1,0,0,1)
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" "Queue" = "Geometry" }
            Pass
            {
                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

                struct Attributes { float4 positionOS : POSITION; float2 uv : TEXCOORD0; };
                struct Varyings { float4 positionCS : SV_POSITION; float2 uv : TEXCOORD0; };

                TEXTURE2D(_MainTex); SAMPLER(sampler_MainTex);
                TEXTURE2D(_PaintMap); SAMPLER(sampler_PaintMap);
                float4 _BaseColor; float4 _PaintColor;

                Varyings vert(Attributes input) {
                    Varyings output;
                    output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                    output.uv = input.uv;
                    return output;
                }

                half4 frag(Varyings input) : SV_Target {
                    // Obtenemos el color de la textura base
                    float4 base = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv) * _BaseColor;

                    // Obtenemos la máscara de pintura (R8)
                    float mask = SAMPLE_TEXTURE2D(_PaintMap, sampler_PaintMap, input.uv).r;

                    // Lógica: Si mask es 1 (blanco), es base. Si mask es 0 (negro), es pintura.
                    float3 finalColor = lerp(_PaintColor.rgb, base.rgb, mask);

                    return float4(finalColor, 1.0);
                }
                ENDHLSL
            }
        }    
}
