using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplicacion : Operaciones
{
  

   public override void  RealizarOperacion()
    {

     if(numero1<numero2 )
        {
            Debug.Log(numero1 + " es menor que " + numero2);
        }
     else if(numero1 > numero2)
        {
            Debug.Log(numero1 + " es mayor que " + numero2);
        }
        else
        {
            Debug.Log(numero1 + " es igual a " + numero2);


        }

        switch (numero1)
        {
            case 1:
                Debug.Log("Elegiste la opción 1");
                Debug.Log("Elegiste la opción 1");
                break;

            case 2:
                Debug.Log("Elegiste la opción 2");
                break;

            case 3:
                Debug.Log("Elegiste la opción 3");
                break;

            default:
                Debug.Log("Opción no válida");
                break;
        }

        float resultado = numero1 * numero2;
        Debug.Log(numero1 + " x " + numero2 + " = " + resultado);

       
    }
}
