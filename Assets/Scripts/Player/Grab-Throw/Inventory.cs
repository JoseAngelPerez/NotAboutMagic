using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

// Clase que se encarga de manejar el inventario de pociones 
// El inventario permite tener dos slots activos, pero cada uno debe ser de pociones distintas y no se pueden llevar más de las permitidas por cada tipo
public class Inventory : MonoBehaviour
{
    public Dictionary<PotionType.TypesOfPotions, float> potionsInventory;

    [SerializeField] private float maxRedPotions, maxBluePotions, maxGreenPotions;
    [SerializeField] private int maxSlots=2;

    public UnityEvent InventoryChange;


    private void Start()
    {
        potionsInventory = new Dictionary<PotionType.TypesOfPotions, float> { {PotionType.TypesOfPotions.BluePotion,0f}, { PotionType.TypesOfPotions.RedPotion, 0f }, { PotionType.TypesOfPotions.GreenPotion, 0f } };
    }

    // Este método revisa revisa sí es posible agregar una poción nueva al inventario
    public bool IsPossibleToAddThisPotion(PotionType.TypesOfPotions potionType)
    {
        // Primero obtiene el porcentaje usado del slot para ese tipo de poción
        float usedSlotPercentage = GetSlotPercentageUsed(potionType);

        // Sí no hay ningún slot siendo usado para ese tipo de poción y aún hay slots completamente vacíos entonces se puede agregr en uno de esos
        if (usedSlotPercentage ==0 && LookForEmptySlots()) 
        return true;

        //Esto indica que ya hay un Slot en uso para este tipo de poción y que no está lleno, por lo tanto se puede agregar una poción de ese tipo
        else if(usedSlotPercentage >0 && usedSlotPercentage < 1)
        return true;

        //sí no hay un slot vacío o uno en uso con espacio para una del mismo tipo entonces no se puede agregar la poción
        else
        return false;

    }

    // Este método revisa qué porcentaje de un slot utilizan las pociones guardadas de un tipo en específico
    private float GetSlotPercentageUsed(PotionType.TypesOfPotions potionType)
    {
        float usedSlotPercentage=0;

        switch (potionType)
        {
            case PotionType.TypesOfPotions.BluePotion:
                usedSlotPercentage = PercentageUsedPerSlot(potionsInventory[PotionType.TypesOfPotions.BluePotion], maxBluePotions);
                break;
            case PotionType.TypesOfPotions.RedPotion:
                usedSlotPercentage = PercentageUsedPerSlot(potionsInventory[PotionType.TypesOfPotions.RedPotion], maxRedPotions);
                break;
            case PotionType.TypesOfPotions.GreenPotion:
                usedSlotPercentage = PercentageUsedPerSlot(potionsInventory[PotionType.TypesOfPotions.GreenPotion], maxGreenPotions);
                break;
            default:
                break;
        }

     return usedSlotPercentage;
    }

    // Revisa sí hay slots vacíos para guardar nuevas pociones, revisando cada tipo de poción y luego sumando el valor total de slots usados
    private bool LookForEmptySlots()
    {
       int slotsInUse = 0;
        if (CheckItemAvailability(PotionType.TypesOfPotions.BluePotion)) slotsInUse++;
        if (CheckItemAvailability(PotionType.TypesOfPotions.RedPotion)) slotsInUse++;
        if (CheckItemAvailability(PotionType.TypesOfPotions.GreenPotion)) slotsInUse++;

        Debug.Log(" use " + slotsInUse + "Max" + maxSlots);
        if(slotsInUse<maxSlots)
            return true;
        else
            return false;
    }

    // Este método nos dice qué porcentaje se ha usado de un slot en especifico
    private float PercentageUsedPerSlot( float potions, float maxPotionsPerSlot)
    {
        float usedSlotPercentage= potions/ maxPotionsPerSlot;
       if(potions == 0)
            return 0;
       else
            return usedSlotPercentage;
    }

    // Método que agrega al inventario una unidad de la poción que se desea agregar
    public void AddPotion(PotionType.TypesOfPotions potionType)
    {
        ManageInventory(potionType, 1);
    }

    // Método que saca del inventario una unidad de la poción que se desea sacar
    public void RemovePotion(PotionType.TypesOfPotions potionType)
    {
        ManageInventory(potionType, -1);
    }

    // Método que cambia las cantidades de la pociones en el inventario
    private void ManageInventory(PotionType.TypesOfPotions potionType, int amountoToChange)
    {
        switch (potionType)
        {
            case PotionType.TypesOfPotions.BluePotion:
                potionsInventory[PotionType.TypesOfPotions.BluePotion] += amountoToChange;
                break;
            case PotionType.TypesOfPotions.RedPotion:
                potionsInventory[PotionType.TypesOfPotions.RedPotion] += amountoToChange;
                break;
            case PotionType.TypesOfPotions.GreenPotion:
                potionsInventory[PotionType.TypesOfPotions.GreenPotion] += amountoToChange;
                break;
            default:
                break;
        }

        InventoryChange?.Invoke();

        Debug.Log(" green " + potionsInventory[PotionType.TypesOfPotions.GreenPotion] + " Blue " + potionsInventory[PotionType.TypesOfPotions.BluePotion] + " Red " + potionsInventory[PotionType.TypesOfPotions.RedPotion]);
    }
  
    // Este método revisa sí quedan existencias de un tipo de poción en específico
    public bool CheckItemAvailability(PotionType.TypesOfPotions potionType)
    {
        float usedSlotPercentage = GetSlotPercentageUsed(potionType);

        if (usedSlotPercentage > 0) 
        return true;

        else
        return false;
    }

    // Este método revisa sí hay algún Slot que esté siendo usado para devolverlo
    public PotionType.TypesOfPotions LoockForAvailableTypeOfPotion()
    {
        float blueSlotPercentage = PercentageUsedPerSlot(potionsInventory[PotionType.TypesOfPotions.BluePotion], maxBluePotions);
        float redSlotPercentage = PercentageUsedPerSlot(potionsInventory[PotionType.TypesOfPotions.RedPotion], maxRedPotions);
        float GreenSlotPercentage = PercentageUsedPerSlot(potionsInventory[PotionType.TypesOfPotions.GreenPotion], maxGreenPotions);

        if (blueSlotPercentage > 0) return PotionType.TypesOfPotions.BluePotion;
        else if (redSlotPercentage > 0) return PotionType.TypesOfPotions.RedPotion;
        else if (GreenSlotPercentage > 0) return PotionType.TypesOfPotions.GreenPotion;
        else return PotionType.TypesOfPotions.NoPotion;


    }


}
