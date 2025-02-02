using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxEffect = 1f;
    private SpriteRenderer[] spriteRenderers;  // Array de sprites hijos del background
    private float[] spriteLengths;  // Anchura de cada sprite
    private Vector3 startPos;  // posicion inicial del background

    void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();  // Obtiene los renderers de los hijos

        // Inicia el array de anchuras y guarda el tamaño de cada sprite
        spriteLengths = new float[spriteRenderers.Length];
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteLengths[i] = spriteRenderers[i].bounds.size.x;
        }

        startPos = transform.position;  // Guarda la posicion inicial
    }

    void Update()
    {
        if (!Controller_Hud.gameOver)
        {
            // Mueve cada sprite individualmente
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].transform.Translate(Vector3.left * parallaxEffect * Time.deltaTime); // Mueve el sprita hacia la izquierda segun el parallaxEffect y el tiempo

                // Reposiciona el sprite cuando se sale completamente de la pantalla
                if (spriteRenderers[i].transform.localPosition.x < -spriteLengths[i])
                {
                    float newX = spriteRenderers[i].transform.localPosition.x + 2 * spriteLengths[i];
                    spriteRenderers[i].transform.localPosition = new Vector3(
                        newX,
                        spriteRenderers[i].transform.localPosition.y,
                        spriteRenderers[i].transform.localPosition.z
                    );
                }
            }
        }
    }
}
