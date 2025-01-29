using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public static float buffVelocity;
    private Rigidbody rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(new Vector3(-buffVelocity, 0, 0), ForceMode.Force);
        OutOfBounds();
    }

    public void OutOfBounds()
    {
        if (transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}

