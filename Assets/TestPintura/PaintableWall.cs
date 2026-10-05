using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableWall : MonoBehaviour
{
    public Shader drawShader;
    public Color paintColor = Color.red;
    [Range(0.01f, 0.2f)] public float brushSize = 0.05f;

    private RenderTexture paintTexture;
    private Material wallMaterial;
    private Material drawMaterial;

    void Start()
    {
        // 1. Crear textura con formato compatible
        paintTexture = new RenderTexture(1024, 1024, 0, RenderTextureFormat.R8);
        paintTexture.Create();

        // 2. Limpiar a blanco (importante: blanco es NO pintado)
        RenderTexture.active = paintTexture;
        GL.Clear(true, true, Color.white);
        RenderTexture.active = null;

        // 3. Obtener la instancia del material y asignar
        wallMaterial = GetComponent<Renderer>().material;
        wallMaterial.SetTexture("_PaintMap", paintTexture);
        wallMaterial.SetColor("_PaintColor", paintColor);

        if (drawShader != null)
            drawMaterial = new Material(drawShader);
    }

    public void PaintAt(Vector2 uv)
    {
        if (drawMaterial == null) return;

        drawMaterial.SetFloat("_Size", brushSize);
        drawMaterial.SetVector("_UV", new Vector4(uv.x, uv.y, 0, 0));

        // Proceso de pintado mediante Blit
        RenderTexture temp = RenderTexture.GetTemporary(paintTexture.width, paintTexture.height, 0, RenderTextureFormat.R8);
        Graphics.Blit(paintTexture, temp, drawMaterial);
        Graphics.Blit(temp, paintTexture);
        RenderTexture.ReleaseTemporary(temp);

        // Refrescar la textura en el material por si acaso
        wallMaterial.SetTexture("_PaintMap", paintTexture);
    }
}
