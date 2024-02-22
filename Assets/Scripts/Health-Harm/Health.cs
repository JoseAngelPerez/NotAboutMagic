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
 
    // M�todo que es llamado cuando recibe da�o
    public void ReduceHealth()
    {
        curentHealth -= damage;
        CheckHealthState();
    }

    // Polimorfismo utilizado por s� es necesario que reciba un valor de da�o espec�fico
    public void ReduceHealth(float specificDamage)
    {
        curentHealth -= specificDamage;
        CheckHealthState();
    }

    // Este m�todo revisa el estado de la salud despu�s de reducirla para dar paso a la muerte en caso de que la salud sea 0
    private void CheckHealthState()
    {
        if(curentHealth<= 0) 
        {
            StartDeath();
        }
    }

    // M�todo que llama al evento que involucra m�todos externos que dan p�e a la muerte del jugador 
    private void StartDeath()
    {
        Death?.Invoke();
    }

    // M�todo que elimina al gameobject que contine este script
    public void RemoveGameObject()
    {
        Destroy(gameObject);
    }

}
