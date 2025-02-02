using UnityEngine;

public class Controller_Buff : MonoBehaviour
{
    public static float buffVelocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(new Vector3(-buffVelocity, 0, 0), ForceMode.Force);
        OutOfBounds();
    }

    // Destruye el game object cuando esta fuera del limite de la camara
    public void OutOfBounds()
    {
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
