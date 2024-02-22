using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// Clase encargada de lanzar objetos
public class ThrowObjects : MonoBehaviour
{
    private HoldObjects holdObjects;
    private PlayerInput playerInput;
  

    private GameObject objectToThrow;

    public UnityEvent ThrowAnObject;

    private void Start()
    {
        holdObjects =GetComponent<HoldObjects>();
    }
    // Al recibir en input del click derecho suelta el objeto y activa su script que lo hace lanzarse
    private void OnThrow()
    {
        if(holdObjects.isHolding)
        {
            objectToThrow = holdObjects.HeldObject;
            ThrowAnObject?.Invoke();
            objectToThrow.GetComponent<ObjectThrown>().Throw();
            objectToThrow.GetComponent<PotionHarm>().MakeItReadyToHarm();
        }
    }
}
