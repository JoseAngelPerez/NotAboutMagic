using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// Clase encargada de soltar objetos
public class DropObjects : MonoBehaviour
{
    private PlayerInput playerInput;

    public UnityEvent DroopAnObject;

    // Este metodo se llama cuando se presiona la tecla C y llama los métodos involucrados en soltar objetos
    private void OnDrop()
    {
        DroopAnObject?.Invoke();
    }
}
