using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase se encarga de que el enemigo ataque al jugador 
public class EnemyShoot : MonoBehaviour
{
    GameObject player;

    [SerializeField] private Transform attackPoint;

    [SerializeField] private GameObject spellToThrow;

    [SerializeField] private float throwForce = 20, throwUpwardForce = 5, timeBetweenShoots= 2;

    Animator enemyAnimator;


    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        enemyAnimator = GetComponent<Animator>();   
    }

    // Este método intancia un proyectil y lo lanza en la dirección del jugador 
    // Se llama a través de un animation event
    private void ThrowASpell()
    {
      
        GameObject projectile = Instantiate(spellToThrow, attackPoint.position, attackPoint.rotation);

       
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

      
        Vector3 forceDirection = attackPoint.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(attackPoint.position, player.transform.position - attackPoint.position, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
    }



}
