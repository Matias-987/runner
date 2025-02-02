using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    private float distance = 0;

    void Start()
    {
        // Inicia el estado del juego
        gameOver = false;
        distance = 0;
        // Configura la UI inicial
        distanceText.text = distance.ToString();
        gameOverText.gameObject.SetActive(false);  // Oculta el texto de game over
    }

    void Update()
    {
        //Logica de fin del juego
        if (gameOver)
        {
            Time.timeScale = 0;  // Pausa el juego
            gameOverText.text = "Game Over \n Total Distance: " + Mathf.Round(distance).ToString();  // Usa interpolacion de strings
            gameOverText.gameObject.SetActive(true);
        }

        else
        {
            // Actualiza la distancia mientras el juego esta activo
            distance += Time.deltaTime;
            distanceText.text = Mathf.Round(distance).ToString();  // Redondea y actualiza la UI
        }
    }
}
