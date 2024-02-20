using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        LookToThePlayer();

  
    }

    private void LookToThePlayer()
    {
        transform.LookAt(playerTransform.position);
    }
}
