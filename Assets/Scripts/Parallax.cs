﻿using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    private float length, startPos;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Verifica si el juego no termino
        if (!Controller_Hud.gameOver)
        {
            transform.position = new Vector3(transform.position.x - parallaxEffect, transform.position.y, transform.position.z);
            if (transform.localPosition.x < -20)
            {
                transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }

    // Metodo para detener el parallax cuando el juego termina
    public void SetGameOver(bool isGameOver)
    {
        Debug.Log("Parallax detenido: " + isGameOver);
    }
}
