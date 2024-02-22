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

    // Pasa a la animaci�n Run
    public void StartChasing()
    {
        enemyAnimator.SetBool("IsAttacking", false);
        enemyAnimator.SetBool("IsRunning", true);
    }

    // Pasa a la animaci�n Attack
    public void StartAttacking()
    {
        enemyAnimator.SetBool("IsRunning", false);
        enemyAnimator.SetBool("IsAttacking", true);
    }

    // Pasa a la animaci�n de death
    public void StartDeath()
    {
        enemyAnimator.SetBool("IsRunning", false);
        enemyAnimator.SetBool("IsAttacking", false);
        enemyAnimator.SetBool("IsDeath", true);
    }

}
