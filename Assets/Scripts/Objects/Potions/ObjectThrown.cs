using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

// clase que hace los objetos lanzables
public class ObjectThrown : MonoBehaviour
{
    Rigidbody rb;
    private Transform throwPoint;
    private Transform mainCamera;

    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float throwForce = 100f, throwUpwardForce = 50f;

    // Usa los transform de la cámara y de un espacio frente a ella como referencia
    public void Start ()
    {
        rb=GetComponent<Rigidbody>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        throwPoint = GameObject.FindGameObjectWithTag("ThrowPoint").transform;
    }

    //Se lanza usando los transfrom de referencia siguiendo un Raycast
    public void Throw()
    {
        Debug.Log("It is been Throw");

        transform.rotation = mainCamera.transform.rotation;
        transform.position= throwPoint.transform.position;

        Vector3 forceDirection = mainCamera.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hit, 500f, layerMask))
        {
            forceDirection = (hit.point - transform.position).normalized;
        } 

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        rb.AddForce(forceToAdd, ForceMode.Impulse);
    }
}
