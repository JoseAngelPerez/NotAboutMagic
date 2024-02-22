using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// esta clase maneja el estado Idle y pasa al chase
public class IdleState : State
{
    public ChaseState chaseState;
    public bool IsInchasingRange;

    public UnityEvent StartChasing;

    private void Update()
    {
        if(IsInchasingRange==false)
        {
            CheckDistancePlayer();
        }
    }

    // Este método se revisa constantemente en la máquina de estados para pasar al siguiente estado
    public override State RunCurrentState()
    {
        if(IsInchasingRange)
        {
            return chaseState;
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

        if (currentDistance<= MaxDistanceToAttack)
        {
            StartChasing?.Invoke();
            IsInchasingRange = true;
        }
    }
}
