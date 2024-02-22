using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

// Clase encargada del salto del personaje
public class InputJump : InputBase
{
    // Buleano que evita que el jugador salte si ya está en el aire
    private bool playerIsJumping;

    private Vector3 vector3Force;

    [SerializeField] private float timeToFall=1, fallForce;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        playerIsJumping = false;
    }

    // El método OnJump es llamado por el input system al presionar la barra espaciadora
    // Revisa si el jugador ya está en el aire y en caso contrario lo deja saltar y bloquea el salto
    public void OnJump()
    {
        if (playerIsJumping ==false)
        {
            rb.AddForce(Vector3.up * movementForce);
            playerIsJumping = true;
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeToFall);
        vector3Force =new Vector3(0, 1, 0);
        rb.velocity = (vector3Force * (-fallForce));
    }

    // Al colisionar contra el suelo le permite al jugador volver a saltar
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Floor" && playerIsJumping==true)
        {
            playerIsJumping= false;
        }
    }
}
