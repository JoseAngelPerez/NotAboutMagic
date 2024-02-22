using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// Clase encargada de agarrar objetos
public class GrabObjects : MonoBehaviour
{
    private PlayerInput playerInput;
    public DetectObjects objectDetetion;

    public UnityEvent GrabAnObject;

    Inventory potionsInventory;

    private HoldObjects holdObjects;

    private void Start()
    {
        playerInput = new PlayerInput();

        objectDetetion = GetComponent<DetectObjects>();

       potionsInventory = transform.parent.gameObject.GetComponent<Inventory>();

        holdObjects = GetComponent<HoldObjects>();
    }

    // Este método es llamado cuando el jugador presiona click izquierdo 
    private void OnGrab()
    {
        if (objectDetetion.objectDetected && potionsInventory.IsPossibleToAddThisPotion(objectDetetion.currentGraspableObject.GetComponent<PotionType>().thisPotionType))
        {
            TakeAnObject();
            if (holdObjects.isHolding== false) ;
            {
                holdObjects.Hold(objectDetetion.currentGraspableObject.GetComponent<PotionType>().thisPotionType);
            }
            Destroy(objectDetetion.currentGraspableObject);
            GrabAnObject?.Invoke();
        }
    }

    // Toma el objeto que está siendo detectado y lo hace hijo de la camara para que siga al personaje
    private void TakeAnObject()
    {
        potionsInventory.AddPotion(objectDetetion.currentGraspableObject.GetComponent<PotionType>().thisPotionType);
    }
 
}
