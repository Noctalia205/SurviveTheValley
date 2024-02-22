using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle: MonoBehaviour
{
    public float interactionRadius = 2f; // Rayon de proximitÃ© pour interagir avec l'objet
    public KeyCode interactionKey = KeyCode.E; // Touche pour l'interaction
    private bool isInRange = false;
    public int nbItems = 0;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactionKey))
        {
            if (gameObject.CompareTag("item")){
                nbItems += 1;
                if (nbItems >= 1){
                    SceneManager.LoadScene("gameOver");
                }
            }
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