using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListasEjemplo : MonoBehaviour
{
    List<int> listEjemplo = new List<int>();
 
    void Start()
    {
        listEjemplo.Add(1);
        listEjemplo.Add(2);
        listEjemplo.Add(3);
        listEjemplo.Add(4);

        Debug.Log("El tamaño de la lista es: " + listEjemplo.Count);

        listEjemplo.Remove(2);

        Debug.Log("El nuevo tamaño de la lista es: " + listEjemplo.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
