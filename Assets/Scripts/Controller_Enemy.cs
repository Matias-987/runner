﻿using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public static float enemyVelocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(new Vector3(-enemyVelocity, 0, 0), ForceMode.Force);
        OutOfBounds();
    }

    // Destruye el game obect cuando esta afuera del limite de la camara
    public void OutOfBounds()
    {
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
