using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// clase encargada del movimiento del jugador
public class InputMovement : InputBase
{
    Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput= GetComponent<PlayerInput>();
    }

    // Recibe los valores del input y desplaza al jugador usando la rotaci�n actual
    private void FixedUpdate()
    {
        moveDirection = rb.rotation * new Vector3(playerInput.actions["Move"].ReadValue<Vector2>().x, 0, playerInput.actions["Move"].ReadValue<Vector2>().y);
        rb.MovePosition(rb.position + (moveDirection * movementForce * Time.fixedDeltaTime));
    }
}
