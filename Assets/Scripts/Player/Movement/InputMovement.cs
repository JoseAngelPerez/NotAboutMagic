using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

// clase encargada del movimiento del jugador
public class InputMovement : InputBase
{
    Vector3 moveDirection;

    //Este evento está hecho para llamar metodos en otras clases cuando el player se mueva
    public UnityEvent playerIsMoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput= GetComponent<PlayerInput>();
    }

    // Recibe los valores del input y desplaza al jugador usando la rotación actual
    private void FixedUpdate()
    {
     
            moveDirection = rb.rotation * new Vector3(playerInput.actions["Move"].ReadValue<Vector2>().x, 0, playerInput.actions["Move"].ReadValue<Vector2>().y);
            rb.MovePosition(rb.position + (moveDirection * movementForce * Time.fixedDeltaTime));
            playerIsMoving?.Invoke();


    }
}
