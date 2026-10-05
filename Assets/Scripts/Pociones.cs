using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pociones : MonoBehaviour
{
    public Referencia referenciaInstANCIA;

    public TMP_Text cantidadFuerza, cantidadVelocidad, cantidadAmor, cantidadInteligencia, cantidadSuerte;
    public Dictionary<string, TMP_Text> textosPociones = new Dictionary<string, TMP_Text>();

    Dictionary<string,int> pociones = new Dictionary<string, int>
    {
    { "Fuerza", 3 },
    { "Velocidad", 3 },
    { "Amor", 3 },
    { "Inteligencia", 3 },
    { "Suerte", 3 }
    };

    private void Start()
    {
        textosPociones.Add("Fuerza", cantidadFuerza);
        textosPociones.Add("Velocidad", cantidadFuerza);
        textosPociones.Add("Amor", cantidadFuerza);
        textosPociones.Add("Inteligencia", cantidadFuerza);
        textosPociones.Add("Suerte", cantidadFuerza);
    }

    public void UsarPociones(string pocionACambiar)
    {
        pociones[pocionACambiar] = pociones[pocionACambiar] -1;
        textosPociones[pocionACambiar].text = pociones[pocionACambiar].ToString();
    }
  

}
