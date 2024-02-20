using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de manejar las animaciones del enemy
public class EnemyAnimationsController : MonoBehaviour
{
    // Accede al animator
    Animator enemyAnimator;

    void Start()
    {
        enemyAnimator= GetComponent<Animator>();
    }

    // Pasa de la animaci�n Idle a Run
    public void StartChasing()
    {
        enemyAnimator.SetBool("IsRunning", true);
    }

    // Pasa de la animaci�n Run a Attack
    public void StartAttacking()
    {
        enemyAnimator.SetBool("IsRunning", false);
        enemyAnimator.SetBool("IsAttacking", true);
    }

}
