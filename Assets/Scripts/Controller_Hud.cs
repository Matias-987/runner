using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    private int distance = 0;

    void Start()
    {
        gameOver = false;
        distance = 0;
        UpdateDistanceText(); // Llama a la nueva funcion.
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Total Distance: " + distance.ToString();
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            distance += Mathf.FloorToInt(Time.deltaTime);
            UpdateDistanceText();
        }
    }

    private void UpdateDistanceText()   // Actualiza el texto de la distancia.
    {
        distanceText.text = distance.ToString();  // Convierte la distancia en string.
    }
}
