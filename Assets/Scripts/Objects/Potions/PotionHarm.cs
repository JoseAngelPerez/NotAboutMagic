using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que hace que las posiones hagan da�o y no se desperdicien al chocar con el ambiente
public class PotionHarm : Harm
{
    private bool isReadyToHarm;
    private void Start()
    {
        isReadyToHarm= false;
        damageObjectiveTag = "Enemy";
    }
    // Al colisionar con su objetivo hacen da�o y desaparecen
    private void OnCollisionEnter(Collision collision)
    {
        if (isReadyToHarm && collision.gameObject.tag == damageObjectiveTag)
        {
            collision.gameObject.GetComponent<Health>().ReduceHealth(damage);
            Destroy(gameObject);
        }
    }

    // Este m�todo activa su capacidad para estallar para que no estallen antes de ser lanzadas
    public void MakeItReadyToHarm()
    {
        isReadyToHarm =true;
    }
}
