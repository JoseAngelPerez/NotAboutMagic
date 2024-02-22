using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// clase que hace que las posiones hagan daño y no se desperdicien al chocar con el ambiente
public class PotionsHarm : Harm
{
    private bool isReadyToHarm;
    private void Start()
    {
        isReadyToHarm= false;
        damageObjectiveTag = "Enemy";
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isReadyToHarm && collision.gameObject.tag == damageObjectiveTag)
        {
            collision.gameObject.GetComponent<Health>().ReduceHealth(damage);
            Destroy(gameObject);
        }
    }
    public void MakeItReadyToHarm()
    {
        isReadyToHarm =true;
    }
}
