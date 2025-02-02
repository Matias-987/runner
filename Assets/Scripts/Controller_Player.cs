using System.Collections;
using UnityEditor.UIElements;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;  // Rigidbody del jugador
    public float jumpForce = 10;
    private float initialSize;  // Escala inicial en el eje Y
    private int i = 0;  // Contador para el estado de agachado
    private bool floored;  // Indica si el jugador esta en el suelo
    private bool isJumping = false;  // Indica si el jugador esta saltando
    private bool isDucking = false;  // Indica si el jugador esta agachado
    private bool isImmune = false;  // Indica si el jugador es invulnerable
    public float rapidezDesplazamiento = 10.0f;
    private Parallax parallax;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;  // Guarda la escala inicial

        parallax = FindObjectOfType<Parallax>(); // Referencia del parallax
    }

    void Update()
    {
        GetInput();  // Actualiza las entraas del jugador (W para saltar, S para agacharse)
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

    private void Jump()  // Maneja la logica del salto
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

    private void Duck()  // Maneja la logica para agacharse
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (i == 0)
                {
                    // Reduce la escala a la mitad en el eje Y
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z); 
                    i++;
                    isDucking = true;
                }
            }

            else
            {
                if (rb.transform.localScale.y != initialSize)
                {
                    // Restaura la escala original
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
                Controller_Hud.gameOver = true;  // Activa el game over
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
        // Llama a la logica del buff
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
        duration = 5f;
        yield return new WaitForSeconds(duration);
        isImmune = false;
    }

    // Metodos publicos para verificar el estado del jugador
    public bool IsJumping()
    {
        return isJumping;
    }

    public bool IsDucking()
    {
        return isDucking;
    }
}
