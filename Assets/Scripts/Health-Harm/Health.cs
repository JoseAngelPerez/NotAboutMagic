using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Clase encargada de manejar la vida del player y del enemy
public class Health : MonoBehaviour
{
    [SerializeField] private float curentHealth, initialHealth=100,damage =20;
    public UnityEvent Death;

    void Start()
    {
        curentHealth = initialHealth;
    }
 
    // Método que es llamado cuando recibe daño
    public void ReduceHealth()
    {
        curentHealth -= damage;
        CheckHealthState();
    }

    // Polimorfismo utilizado por sí es necesario que reciba un valor de daño específico
    public void ReduceHealth(float specificDamage)
    {
        curentHealth -= specificDamage;
        CheckHealthState();
    }

    // Este método revisa el estado de la salud después de reducirla para dar paso a la muerte en caso de que la salud sea 0
    private void CheckHealthState()
    {
        if(curentHealth<= 0) 
        {
            StartDeath();
        }
    }

    // Método que llama al evento que involucra métodos externos que dan píe a la muerte del jugador 
    private void StartDeath()
    {
        Death?.Invoke();
    }

    // Método que elimina al gameobject que contine este script
    public void RemoveGameObject()
    {
        Destroy(gameObject);
    }

}
