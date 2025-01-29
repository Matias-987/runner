using System.Collections;
using UnityEngine;

public class Slow : Buffs
{
    public float reduccionDeRapidez = 0.5f;

    protected override void Start() 
    {
        base.Start(); 
    }

    public void UsarItem(GameObject player) 
    {
        Controller_Player playerController = player.GetComponent<Controller_Player>();
        if (playerController != null)
        {
            playerController.rapidezDesplazamiento *= reduccionDeRapidez;
            StartCoroutine(RestablecerRapidezOriginal(playerController));
        }
    }

    private IEnumerator RestablecerRapidezOriginal(Controller_Player playerController)
    {
        yield return new WaitForSeconds(5.0f);

        if (playerController != null)
        {
            playerController.rapidezDesplazamiento /= reduccionDeRapidez;
        }
    }
}

