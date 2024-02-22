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
