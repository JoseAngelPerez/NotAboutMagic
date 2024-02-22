using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase Base de los estados del enemy
public abstract class State : MonoBehaviour
{
    public abstract State RunCurrentState();

    protected GameObject player;
    [SerializeField] protected float currentDistance, MaxDistanceToAttack = 10;
    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
