using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> buffs;
    public GameObject instantiatePos;
    public float enemyRespawnTimer;
    public float buffRespawnTimer;
    private float time = 0;

    void Start()
    {
        Controller_Enemy.enemyVelocity = 2;  // Velocidad inicial de los enemigos
    }

    void Update()
    {
        SpawnEnemies();
        SpawnBuffs();
        ChangeVelocity();
    }

    // Logica de velocidad
    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
        Controller_Buff.buffVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    private void SpawnEnemies()
    {
        enemyRespawnTimer -= Time.deltaTime;  // Temporizador de spawn

        if (enemyRespawnTimer <= 0)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count)], instantiatePos.transform);  // Elige un enemigo aleatorio de la lista y lo spawnea
            enemyRespawnTimer = Random.Range(2, 6);  // Rango de tiempo en el que spawnea
        }
    }

    private void SpawnBuffs()
    {
        buffRespawnTimer -= Time.deltaTime;  // Temporizador de spawn

        if (buffRespawnTimer <= 0)
        {
            Instantiate(buffs[Random.Range(0, buffs.Count)], instantiatePos.transform);  // Elige un buff aleatorio e la lista y lo spawnea
            buffRespawnTimer = Random.Range(11, 21);  // Rango de tiempo en el que spawnea
        }
    }
}

