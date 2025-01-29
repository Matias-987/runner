using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other); // Detecta cuando el jugaor entra al trigger
    }

    private void OnTriggerStay(Collider other)
    { 
        HandleCollision(other); // Detecta cuando el jugador esta dentro del trigger
    }
    private void HandleCollision(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador colisiona con el enemigo
        {
            Controller_Player player = other.GetComponent<Controller_Player>();

            if (player != null)
            {
                // Verifica si el jugador esta saltando o agachandose
                if (player.IsJumping() || player.IsDucking())
                {
                    // El jugador pierde
                    Destroy(player.gameObject);
                    Controller_Hud.gameOver = true;
                }
            }
        }
    }
}
