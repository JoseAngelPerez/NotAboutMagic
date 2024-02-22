using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Clase encargada de manejar los elementos en panatalla del inventario
public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject redImage, blueImage, greenImage;

    [SerializeField] private TMP_Text redAmount, blueAmount, greenAmount;

    Inventory potionsInventory;

    private void Start()
    {
        potionsInventory= GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        redImage.SetActive(false);
        blueImage.SetActive(false);
        greenImage.SetActive(false);
    }

    // este método actauliza el estado de los valores y sí la imagen de una poción está activa o no, es llamada por un evento en el inventario
    public void UpdateInventory()
    {
       if( potionsInventory.CheckItemAvailability(PotionType.TypesOfPotions.BluePotion))
        {
            blueImage.SetActive(true);
        }

        else
        {
            blueImage.SetActive(false);
        }

        if (potionsInventory.CheckItemAvailability(PotionType.TypesOfPotions.RedPotion))
        {
            redImage.SetActive(true);
        }
        else
        {
            redImage.SetActive(false);
        }

        if (potionsInventory.CheckItemAvailability(PotionType.TypesOfPotions.GreenPotion))
        {
            greenImage.SetActive(true);
        }
        else
        {
            greenImage.SetActive(false);
        }

        redAmount.text = potionsInventory.potionsInventory[PotionType.TypesOfPotions.RedPotion].ToString();

        blueAmount.text = potionsInventory.potionsInventory[PotionType.TypesOfPotions.BluePotion].ToString();

        greenAmount.text = potionsInventory.potionsInventory[PotionType.TypesOfPotions.GreenPotion].ToString();
    }
}
