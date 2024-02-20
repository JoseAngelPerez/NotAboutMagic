using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Esta clase maneja el estado Chase y pasa al estado Attack
public class ChaseState : State
{
    public AttackState attackState;
    public bool isInAttackRange;

    public UnityEvent StartAttacking;


    public override State RunCurrentState()
    {
        if(isInAttackRange)
        {
            return attackState;
        }

        else
        {
            return this;
        }
    }

    // Sí el jugador entra en el rango de ataque pasa de estdo y comienza a atacar
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isInAttackRange == false )
            {
                StartAttacking?.Invoke();
                isInAttackRange = true;
            }
        }
    }
}
