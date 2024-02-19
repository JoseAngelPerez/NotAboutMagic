using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Clase encargada de detectar objetos para que estos puedan ser agarrados 
public class DetectObjects : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] private float maxDetectionDistance =2f;
    public GameObject currentGraspableObject { get; private set; }
    public bool objectDetected { get; private set; }

    private void Start()
    {
        objectDetected= false;
    }

    void Update()
    {
     Detect();
    }

    //Genera un Ray cast desde el centro de la c�mara y verifica s� colisiona con un objeto que sea agarrable
    private void Detect()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance <= maxDetectionDistance  && objectDetected == false && hit.collider.gameObject.tag == "GraspableObject")
            {
                // Define el objeto como detectectado y lo guarda en una variable para agarrarlo
                currentGraspableObject = hit.collider.gameObject;
                objectDetected = true;

                Debug.Log("Object Detected");
            }
        }
        // S� se deja de detectar el objeto este se remueve para dar paso a detectar otro
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