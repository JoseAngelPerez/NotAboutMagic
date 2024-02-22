using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de manejar los estados del enemy
public class StateManager : MonoBehaviour
{
   [SerializeField] private State currentState;

    private void Update()
    {
        RunStateMachine();
    }

    // Revisa constantemente el estado actual, el cual es actualizado por el propio estado y sí hay un cambio lo procesa
    private void RunStateMachine()
    {
        State nextState= currentState?.RunCurrentState();

        if (nextState != null) 
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }
}
