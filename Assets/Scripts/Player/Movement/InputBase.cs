using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Clase padre del salto, el movimiento y la rotación (InputJump, InputMovement, InputRotation)
public abstract class InputBase : MonoBehaviour
{
    // Accede al rigidbody y crea una instancia del input system
    protected PlayerInput playerInput;
    protected Rigidbody rb;

    // variable que determina fuerza de movimiento 
    [SerializeField] protected float movementForce = 200f;

}
