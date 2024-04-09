using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle: MonoBehaviour
{
    public float interactionRadius = 2f; // Rayon de proximité pour interagir avec l'objet
    public KeyCode interactionKey = KeyCode.E; // Touche pour l'interaction
    private bool isInRange = false;
    public int nbItems = 0;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactionKey))
        {
            if (gameObject.CompareTag("item")){
                nbItems ++;
                Debug.Log("item trouver" + nbItems);
                if (nbItems == 3){
                    SceneManager.LoadScene("Victory");
                }
                gameObject.SetActive(false);
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