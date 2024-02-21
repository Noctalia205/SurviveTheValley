using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public float interactionRadius = 2f; // Rayon de proximité pour interagir avec l'objet
    public KeyCode interactionKey = KeyCode.E; // Touche pour l'interaction
    private bool isInRange = false;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactionKey))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
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

    private void Interact()
    {
        // Ajoutez ici le code spécifique à l'interaction que vous souhaitez réaliser
        Debug.Log("Interaction avec l'objet !");
    }
}
