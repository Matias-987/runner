﻿using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    private float length, startPos;
    public float parallaxEffect;

    private bool gameOver = false;  // Evita que el parallax se mueva cuando el juego termine.

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (!gameOver)
        {
            MoveParallax(); // Mueve el parallax solo si el juego sigue sin terminar.
        }
    }

    void MoveParallax()
    {
        transform.position = new Vector3 (transform.position.x - parallaxEffect * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x < startPos - length)
        {
            transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
        }
    }

    public void SetGameOver(bool isGameOver) // Activa la condicion de juego perdido.
    {
        gameOver = isGameOver;
    }
}
