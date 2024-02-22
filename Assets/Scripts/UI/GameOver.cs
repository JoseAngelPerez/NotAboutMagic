using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de aactivar la pantalla de game over
public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    // Inicia inactiva
    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Al llamar este evento se activa
    public void ActivateGameOverScreen()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}
