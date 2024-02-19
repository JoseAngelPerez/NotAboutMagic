using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de manejar los estados del enemy
public class StateManager : MonoBehaviour
{
    private State currentState;

    private void Update()
    {
        RunStateMachine();
    }

    //Revisa constantemente el estado actual
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
