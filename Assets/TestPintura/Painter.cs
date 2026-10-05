using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    [Header("Configuración de Pintura")]
    public string paintableTag = "ParedPintable";

    // El Raycast necesita una pequeña distancia para asegurar que detecta la superficie
    public float rayDistance = 0.5f;

    void OnCollisionStay(Collision collision)
    {
        // 1. Verificamos si el objeto con el que chocamos tiene el Tag correcto
        if (collision.gameObject.CompareTag(paintableTag))
        {
            PaintableWall wall = collision.gameObject.GetComponent<PaintableWall>();

            if (wall != null)
            {
                // 2. Disparamos un Raycast desde el centro de la esfera hacia el punto de contacto
                // Esto es necesario para obtener las coordenadas UV precisas
                RaycastHit hit;
                Vector3 hitPoint = collision.contacts[0].point;
                Vector3 direction = hitPoint - transform.position;

                if (Physics.Raycast(transform.position, direction.normalized, out hit, rayDistance))
                {
                    // 3. Verificamos que lo que el Raycast golpeó sea realmente la pared
                    if (hit.collider.gameObject == collision.gameObject)
                    {
                        // IMPORTANTE: Usamos textureCoord para mapear el dibujo a la textura
                        Vector2 uv = hit.textureCoord;
                        wall.PaintAt(uv);
                    }
                }
            }
        }
    }
}
