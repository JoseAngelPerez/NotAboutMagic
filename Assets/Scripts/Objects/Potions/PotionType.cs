using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de definir el tipo de poci�n para ser guardada en el inventario
public class PotionType : MonoBehaviour
{
    [SerializeField] public TypesOfPotions thisPotionType;
    public enum TypesOfPotions
    {
     RedPotion,
     BluePotion,
     GreenPotion,
     NoPotion
    }
}
