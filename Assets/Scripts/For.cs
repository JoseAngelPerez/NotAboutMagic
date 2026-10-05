using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For : MonoBehaviour
{
    public GameObject cubo;
   public void Apagar()
    {
        cubo.SetActive(false);
        Debug.Log("Se ha apagado la bola");
    }

    public void Prender()
    {
        cubo.SetActive(true);
        Debug.Log("Se ha prendido la bola");
    }
}
