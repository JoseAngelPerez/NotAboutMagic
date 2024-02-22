using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// El estado de ataque solo se devuelva a s� mismo para permanecer a perpetuidad como estado activo en la m�quina de estados
public class AttackState : State
{
    public override State RunCurrentState()
    {
            return this;
    }
}
