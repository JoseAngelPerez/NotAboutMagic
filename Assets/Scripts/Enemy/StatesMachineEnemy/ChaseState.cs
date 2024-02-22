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

    private void Update()
    {
        if (isInAttackRange == false)
        {
            CheckDistancePlayer();
        }
    }

    // Este método se revisa constantemente en la máquina de estados para pasar al siguiente estado
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

    // Este método revisa la distancia respecto al jugador y en caso de estar lo suficientemente cerca cambia de estado
    private void CheckDistancePlayer()
    {
        currentDistance = Vector3.Distance(player.transform.position, transform.position);

        if (currentDistance <= MaxDistanceToAttack)
        {
            StartAttacking?.Invoke();
            isInAttackRange = true;
        }
    }
}
