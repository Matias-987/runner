using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagEnemy : MonoBehaviour
{
    public float zigzagSpeed = 2f;
    public float zigzagAmplitude = 1f;
    public float initialY;
    private bool movingUp = true;
    void Start()
    {
        initialY=transform.position.y;
    }

    void Update()
    {
        // Calcula la nueva posicion en el eje Y
        float newY = transform.position.y + (movingUp ? zigzagSpeed : -zigzagSpeed) * Time.deltaTime;

        // Limita el movimiento dentro de la amplitud definida
        if (newY > initialY + zigzagAmplitude)
        {
            newY = initialY + zigzagAmplitude;
            movingUp = false; // Cambia la direccion hacia abajo
        }
        else if (newY < initialY - zigzagAmplitude)
        {
            newY = initialY - zigzagAmplitude;
            movingUp = true; // Cambia la direccion hacia arriba
        }

        // Aplica la nueva posicion
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Floor"))
        {
            movingUp = !movingUp; // Invierte la ireccion el movimiento una vez que colisione con el piso
        }
    }
}
