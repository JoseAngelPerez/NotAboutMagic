using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// Clase encargada de agarrar objetos
public class GrabObjects : MonoBehaviour
{
    private PlayerInput playerInput;
    private DetectObjects objectDetetion;

    private Transform grabPosition;
    public GameObject grabbedObject;

    public UnityEvent GrabAnObject;

    public bool objectIsGrabbed;

    private void Start()
    {
        playerInput = new PlayerInput();

        objectDetetion = GetComponent<DetectObjects>();
        grabPosition = GameObject.FindGameObjectWithTag("GrabPosition").transform;

        objectIsGrabbed = false;
    }

    // Este método es llamado cuando el jugador presiona click izquierdo 
    private void OnGrab()
    {
        if (objectDetetion.objectDetected && objectIsGrabbed == false)
        {
            TakeAnObject();
            GrabAnObject.Invoke();
        }
    }

    // Toma el objeto que está siendo detectado y lo hace hijo de la camara para que siga al personaje
    private void TakeAnObject()
    {
        grabbedObject = objectDetetion.currentGraspableObject;
        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        grabbedObject.transform.parent = transform;
        grabbedObject.transform.rotation = grabPosition.transform.rotation;
        grabbedObject.transform.position = grabPosition.transform.position;
        objectIsGrabbed = true;
    }

    // Remueve el objeto como hijo y regresa su RigidBody a la normalidad
    public void UnhandAnObject()
    {
        if(objectIsGrabbed)
        {
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject = null;
            objectIsGrabbed = false;
        }
    }
}
