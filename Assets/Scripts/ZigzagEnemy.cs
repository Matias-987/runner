using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagEnemy : MonoBehaviour
{
    public float zigzagSpeed = 2f;
    public float zigzagAmplitude = 1f;
    public float initialY;
    void Start()
    {
        initialY=transform.position.y;
    }

    void Update()
    {
        float newY = initialY + Mathf.Sin(Time.time *zigzagSpeed) * zigzagAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
