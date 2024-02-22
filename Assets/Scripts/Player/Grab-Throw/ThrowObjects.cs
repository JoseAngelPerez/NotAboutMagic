using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// Clase encargada de lanzar objetos
public class ThrowObjects : MonoBehaviour
{
    private PlayerInput playerInput;
    private GrabObjects grabObjects;

    private GameObject objectToThrow;

    public UnityEvent ThrowAnObject;

    private void Start()
    {
        grabObjects=GetComponent<GrabObjects>();
    }
    // Al recibir en input del click derecho suelta el objeto y activa su script que lo hace lanzarse
    private void OnThrow()
    {
        if(grabObjects.objectIsGrabbed)
        {
            objectToThrow = grabObjects.grabbedObject;
            ThrowAnObject?.Invoke();
            objectToThrow.GetComponent<ObjectThrown>().Throw();
            objectToThrow.GetComponent<PotionsHarm>().MakeItReadyToHarm();
        }
    }
}
