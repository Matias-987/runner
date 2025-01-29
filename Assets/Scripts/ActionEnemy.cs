using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Controller_Player player = other.GetComponent<Controller_Player>();

            // Verifica si el ugor salta o se agacha
            if (player.IsJumping() || player.IsDucking())
            {
                Destroy(player.gameObject);
                Controller_Hud.gameOver = true;
            }
        }
    }
}
