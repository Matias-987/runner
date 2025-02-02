using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class PowerUp_Inmunity : MonoBehaviour
{
    public float immunityDuration = 5f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActivateImmunity()); // Inicia la inmunidad
            GetComponent<Collider>().enabled = false; // Desactiva el collider para evitar multiples activaciones
            GetComponent<Renderer>().enabled = false; // Hace invisible el buff (opcional)
            Destroy(gameObject, immunityDuration); // Destruye el buff despues de la inmunidad
        }
    }

    // Logica de la inmunidad
    public IEnumerator ActivateImmunity()
    {
        int playerLayer = LayerMask.NameToLayer("Player");
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        SetEnemyCollisions(enemyLayer, ignore: true);

        yield return new WaitForSeconds(immunityDuration);

        SetEnemyCollisions(enemyLayer, ignore: false);
    }

    // Logica para ignorar las colisiones con los enemigos
    private void SetEnemyCollisions(int enemyLayer, bool ignore)
    {
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics.IgnoreLayerCollision(playerLayer, enemyLayer, ignore);
    }
}
