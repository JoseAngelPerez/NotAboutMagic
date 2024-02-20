using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// esta clase maneja el estado Idle y pasa al chase
public class IdleState : State
{
    public ChaseState chaseState;
    public bool canSeeThePlayer;

    private void Start()
    {
        canSeeThePlayer= false;
    }

    // Cambia de estado al tener al jugador 
    public override State RunCurrentState()
    {
        if(canSeeThePlayer)
        {
            return chaseState;
        }

        else
        {
            return this;
        }
    }
    
    //Revisa sí el jugador ingresó a la zona del enemigo para cambiar de estado y comenzar a perseguirlo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (canSeeThePlayer == false)
            {
                canSeeThePlayer = true;
            }
        }
    }
}
