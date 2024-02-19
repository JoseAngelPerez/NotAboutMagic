using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Clase encargada de la rotaci�n de la c�mara 
public class InputRotation : InputBase
{
    // Toma una referencia del Player para girarlo con ella 
    [SerializeField] private Transform playerTransform;

    private float mouseX, mouseY, xRotation;

    private void Start()
    {
        playerInput = new PlayerInput();
        playerTransform= GameObject.FindWithTag("Player").transform;

        Cursor.visible = false;
    }

    // El m�todo OnRotate es llamado por el input system al mover el mouse
    // Gira la c�mara usando el input del mouse y una fuerza base
    private void OnRotate(InputValue inputValue)
    {
        mouseX = inputValue.Get<Vector2>().x * movementForce;
        mouseY = inputValue.Get<Vector2>().y * movementForce;

        xRotation -= mouseY;

        // Limita la rotaci�n vertical de la c�mara 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);

    }
}
