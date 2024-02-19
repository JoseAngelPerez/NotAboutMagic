using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

// Clase encargada del salto del personaje
public class InputJump : InputBase
{
    // Buleano que evita que el jugador salte si ya está en el aire
    private bool playerIsJumping;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        playerIsJumping = false;
    }

    // El método OnJump es llamado por el input system al presionar la barra espaciadora
    // Revisa si el jugador ya está en el aire y en caso contrario lo deja saltar y bloquea el salto
    private void OnJump()
    {
        if (playerIsJumping ==false)
        {
            rb.AddForce(Vector3.up * movementForce);
            playerIsJumping= true;
        }
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
