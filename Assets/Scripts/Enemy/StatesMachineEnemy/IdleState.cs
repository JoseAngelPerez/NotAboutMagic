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

    // Cambia de estado al tener al jugador en su rango de acción
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

    // Revisa las distancia actual respecto al player
    private void CheckDistancePlayer()
    {
        currentDistance = Vector3.Distance(player.transform.position, transform.position);

        if (currentDistance<= MiniDistancetoDetect)
        {
            StartChasing?.Invoke();
            IsInchasingRange = true;
        }
    }
}
