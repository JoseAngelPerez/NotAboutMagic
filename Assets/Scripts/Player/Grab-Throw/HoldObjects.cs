using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de sostener objetos al frente de la cámara del jugador 
public class HoldObjects : MonoBehaviour
{
    public GameObject HeldObject;
    private Transform holdingPosition;
    public bool isHolding;
    Inventory potionsInventory;
    [SerializeField] GameObject redPotion, bluePotion, greenPotion;

    private void Start()
    {
        holdingPosition = GameObject.FindGameObjectWithTag("GrabPosition").transform;
        potionsInventory = transform.parent.gameObject.GetComponent<Inventory>();
        isHolding = false;
    }

    // Pone al fente del jugador una poción del tipo espacíficado
    public void Hold(PotionType.TypesOfPotions potionType)
    {
        if (isHolding==false)
        {
            GameObject newPotion;

            switch (potionType)
            {
                case PotionType.TypesOfPotions.BluePotion:
                    newPotion = bluePotion;
                    break;
                case PotionType.TypesOfPotions.RedPotion:
                    newPotion = redPotion;
                    break;
                case PotionType.TypesOfPotions.GreenPotion:
                    newPotion = greenPotion;
                    break;
                default:
                    newPotion = null;
                    break;
            }
            HeldObject = Instantiate(newPotion, holdingPosition.position, holdingPosition.rotation);
            HeldObject.GetComponent<Rigidbody>().isKinematic = true;
            HeldObject.transform.parent = transform;
            isHolding = true;
        }
    }

    //Suelta el objeto actual y revisa sí hay otro disponible en el inventario para agarrar
    public void UnhandAnObject()
    {

        Debug.Log("try");
        potionsInventory.RemovePotion(HeldObject.GetComponent<PotionType>().thisPotionType);
        HeldObject.transform.parent = null;
        HeldObject.GetComponent<Rigidbody>().isKinematic = false;
        isHolding = false;
        if (potionsInventory.CheckItemAvailability(HeldObject.GetComponent<PotionType>().thisPotionType))
        {
           
            Debug.Log("Hold same");
            Hold(HeldObject.GetComponent<PotionType>().thisPotionType);
        }
        else if (potionsInventory.LoockForAvailableTypeOfPotion() != PotionType.TypesOfPotions.NoPotion)
        {
            
            Hold(potionsInventory.LoockForAvailableTypeOfPotion());
            Debug.Log("Hold new");
        }
        else
        {
            Debug.Log("no object");
            HeldObject = null;
        }
    }
}
