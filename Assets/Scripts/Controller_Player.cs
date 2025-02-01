using System.Collections;
using UnityEditor.UIElements;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    private float initialSize;
    private int i = 0;
    private bool floored;
    private bool isJumping = false;
    private bool isDucking = false;
    private bool isImmune = false;

    public float rapidezDesplazamiento = 10.0f;

    private Parallax parallax;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;

        parallax = FindObjectOfType<Parallax>(); // Referencia del parallax
    }

    void Update()
    {
        GetInput();
    }

    private void VelocidadJugador()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.velocity = movement * rapidezDesplazamiento;
    }

    private void GetInput()
    {
        Jump();
        Duck();
    }

    private void Jump()
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                isJumping = true;
            }
        }
    }

    private void Duck()
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (i == 0)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                    isDucking = true;
                }
            }

            else
            {
                if (rb.transform.localScale.y != initialSize)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                    isDucking = false;
                }
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!isImmune)
            {
                Destroy(gameObject);
                Controller_Hud.gameOver = true;
            }
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("buff"))
        {
            PowerUp_Inmunity buff = other.gameObject.GetComponent<PowerUp_Inmunity>();
            if (buff != null)
            {
                StartCoroutine(buff.ActivateImmunity());
                isImmune = true;
                StartCoroutine(ResetImmunity(buff.immunityDuration));
            }
        }
    }

    private IEnumerator ResetImmunity(float duration)
    {
        yield return new WaitForSeconds(duration);
        isImmune = false;
    }
    public bool IsJumping()
    {
        return isJumping;
    }

    public bool IsDucking()
    {
        return isDucking;
    }
}
