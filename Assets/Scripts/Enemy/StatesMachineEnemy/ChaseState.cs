using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase maneja el estado Idle y pasa al estado Attack
public class ChaseState : State
{
    public AttackState attackState;
    public bool isInAttackRange;
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
}
