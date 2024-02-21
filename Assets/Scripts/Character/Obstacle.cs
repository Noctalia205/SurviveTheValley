using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E; // Touche pour l'interaction
    private bool isInRange = false;
    public GameObject cube; // Référence au cube à faire apparaître/disparaître
    public int nbPressionBouton = 0;

    private void Update()
    {
        // Vérifie si le joueur est dans la zone d'interaction et appuie sur la touche d'interaction
        if (isInRange && Input.GetKeyDown(interactionKey))
        {
            nbPressionBouton ++;
            if (nbPressionBouton == 4)
            {
                Debug.Log("Omg y a Bonnie");
            }
              
            // Lance la coroutine pour faire réapparaître et disparaître le cube
            StartCoroutine(ShowAndHideCubeRepeatedly());
        }
    }

    IEnumerator ShowAndHideCubeRepeatedly()
    {
        int numRepeats = 10; // Nombre de répétitions (à ajuster selon vos besoins)
        float interval = 0.1f; // Intervalle entre chaque répétition (en secondes)
        
        for (int i = 0; i < numRepeats; i++)
        {
            // Active le cube
            cube.SetActive(true);

            // Attend un court instant
            yield return new WaitForSeconds(interval);

            // Désactive le cube
            cube.SetActive(false);

            // Attend un court instant
            yield return new WaitForSeconds(interval);

            // Réactive le cube à la fin de la séquence de répétitions
        cube.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("mainChar"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("mainChar"))
        {
            isInRange = false;
        }
    }
}
