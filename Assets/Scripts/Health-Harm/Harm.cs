using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase maneja el comportamiento del EnemySpell una vez colisiona con algo
public class Harm : MonoBehaviour
{
    [SerializeField] protected float damage =50f;
    [SerializeField] protected string damageObjectiveTag;

    // Este método destruye el objeto siempre que colisiona, pero si lo hace con el gameobject indicado le hace daño
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == damageObjectiveTag) 
        {
            other.gameObject.GetComponent<Health>().ReduceHealth(damage);
            Destroy(gameObject);
        }
        // Esto es para evitar que las cosas que le hacen daño al jugador se destruyan entre ellas 
        else if(other.gameObject.tag == "Obstacle"|| other.gameObject.tag == "Enemy")
        {
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
