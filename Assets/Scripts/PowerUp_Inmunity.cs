using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Inmunity : MonoBehaviour
{
    public float immunityDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Controller_Player player = other.GetComponent<Controller_Player>();

            if (player != null)
            {
                player.ActivateImmunity(immunityDuration);
                Destroy(gameObject);
            }
        }
    }
}
