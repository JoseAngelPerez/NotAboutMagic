using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Suma : Operaciones
{

    public TMP_Text textoResultado;

    public TMP_InputField  inputField1, inputField2;
    public override void RealizarOperacion()
    {
        float resultado = float.Parse(inputField1.text) + float.Parse(inputField2.text);
        
        textoResultado.text = resultado.ToString();
    }

}
