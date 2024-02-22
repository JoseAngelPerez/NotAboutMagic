using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase Base de los estados del enemy
public abstract class State : MonoBehaviour
{
    //Las necesidades comunes de los esados son la posición del player y el estado que le pasan a la máquina de estados
    public abstract State RunCurrentState();

    protected GameObject player;
    [SerializeField] protected float currentDistance, MaxDistanceToAttack = 10;
    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
