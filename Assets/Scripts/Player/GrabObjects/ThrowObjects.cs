using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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
    private void OnThrow()
    {
        if(grabObjects.objectIsGrabbed)
        {
            objectToThrow = grabObjects.grabbedObject;
            ThrowAnObject?.Invoke();
            objectToThrow.GetComponent<ObjectThrown>().Throw();
        }
    }
}
