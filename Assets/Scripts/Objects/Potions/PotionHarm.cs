using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que hace que las posiones hagan daño y no se desperdicien al chocar con el ambiente
public class PotionHarm : Harm
{
    private bool isReadyToHarm;
    private void Start()
    {
        isReadyToHarm= false;
        damageObjectiveTag = "Enemy";
    }
    // Al colisionar con su objetivo hacen daño y desaparecen
    private void OnCollisionEnter(Collision collision)
    {
        if (isReadyToHarm && collision.gameObject.tag == damageObjectiveTag)
        {
            collision.gameObject.GetComponent<Health>().ReduceHealth(damage);
            Destroy(gameObject);
        }
    }

    // Este método activa su capacidad para estallar para que no estallen antes de ser lanzadas
    public void MakeItReadyToHarm()
    {
        isReadyToHarm =true;
    }
}
