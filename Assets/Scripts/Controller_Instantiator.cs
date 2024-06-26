﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> buffs;
    public GameObject instantiatePos;
    public float respawningTimer;
    private float time = 0;

    void Start()
    {
        Controller_Enemy.enemyVelocity = 2;
        Buffs.buffVelocity = 2;
    }

    void Update()
    {
        SpawnEnemies();
        SpawnBuffs();
        ChangeVelocity();
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    private void SpawnEnemies()
    {
        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count)], instantiatePos.transform);
            respawningTimer = Random.Range(2, 6);
        }
    }

    private void SpawnBuffs()
    {
        respawningTimer -= Time.deltaTime;
        if (respawningTimer <= 0)
        {
            Instantiate(buffs[Random.Range(0, buffs.Count)], instantiatePos.transform);
            respawningTimer = Random.Range(2, 6);
        }
    }
}

