using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// Esta Clase se encarga de que el enemy persiga al player
public class EnemyMovement : MonoBehaviour
{
    GameObject player;

    public NavMeshAgent agent;

    private bool isChasing;

    private void Start()
    {
        isChasing= false;

        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<InputMovement>().playerIsMoving.AddListener(FollowPlayer);

    }


    void Update()
    {
        LookToThePlayer();
    }

    //Este método hace que el enemigo simpre mire en dirección al jugador 
    private void LookToThePlayer()
    {
        transform.LookAt(player.transform.position);
    }

    //Este método habilita que el enemigo comience al perseguir al jugador 
    public void StartChasingPlayer()
    {
        isChasing= true;
    }

    //Este método hace que el enemigo deje de perseguir al jugador 

    public void StopChasingPlayer()
    {
        isChasing = false;
        agent.Stop();
    }

    // Este método cambia la posición objetivo del NaveMeshAgent para actualizarse con la posición actual del jugador
    public void FollowPlayer()
    {
        if (isChasing)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
