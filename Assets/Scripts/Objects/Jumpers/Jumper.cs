using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que hace que los jumpers funcionen
public class Jumper : MonoBehaviour
{
    // Al colicionar con un player lo hace saltar con su propio script
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<InputJump>().OnJump();
            Destroy(gameObject);
        }
    }
}

