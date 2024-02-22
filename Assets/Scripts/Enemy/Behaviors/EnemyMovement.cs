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

    //Este m�todo hace que el enemigo simpre mire en direcci�n al jugador 
    private void LookToThePlayer()
    {
        transform.LookAt(player.transform.position);
    }

    //Este m�todo habilita que el enemigo comience al perseguir al jugador 
    public void StartChasingPlayer()
    {
        isChasing= true;
    }

    //Este m�todo hace que el enemigo deje de perseguir al jugador 

    public void StopChasingPlayer()
    {
        isChasing = false;
        agent.Stop();
    }

    // Este m�todo cambia la posici�n objetivo del NaveMeshAgent para actualizarse con la posici�n actual del jugador
    public void FollowPlayer()
    {
        if (isChasing)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
