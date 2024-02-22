using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Clase encargada de detectar objetos para que estos puedan ser agarrados 
public class DetectObjects : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] private float maxDetectionDistance =2f;
    public GameObject currentGraspableObject;
    public bool objectDetected { get; private set; }

    // Numero de layer en el que están las posiones, es para que el Raycast omita los demás objetos
    private int layerNumber = 6;
    private int layerMask;

    private void Start()
    {
        objectDetected= false;
        layerMask = 1 << layerNumber;
    }

    void Update()
    {
     Detect();
    }

    //Genera un Ray cast desde el centro de la cámara y verifica sí colisiona con un objeto que sea agarrable
    private void Detect()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask  ) && hit.collider.gameObject.tag == "GraspableObject")
        {
            if (hit.distance <= maxDetectionDistance  && objectDetected == false && hit.collider.gameObject.tag == "GraspableObject")
            {
                // Define el objeto como detectectado y lo guarda en una variable para agarrarlo
                currentGraspableObject = hit.collider.gameObject;
                objectDetected = true;
            }
        }

        // Sí se detecta un objeto que no sea un GraspableObject remueve cualquier objeto detectado
        else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag != "GraspableObject")
        {
            RemoveDetectedObject();
        }

        // Sí se deja de detectar objetos se remueve cualquier objeto detectado
        else
        {
            RemoveDetectedObject();
        }
    }
    public void RemoveDetectedObject()
    {
        currentGraspableObject = null;
        objectDetected = false;
    }

}
