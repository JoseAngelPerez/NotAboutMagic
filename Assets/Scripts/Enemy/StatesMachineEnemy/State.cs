using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase Base de los estados del enemy
public abstract class State : MonoBehaviour
{
    public abstract State RunCurrentState();
}
