using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E; // Touche pour l'interaction
    private bool isInRange = false;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactionKey))
        {
            Player player = FindObjectOfType<Player>(); // Trouve le joueur dans la scène
            if (player != null)
            {
                player.nbItems+=1;
                Destroy(gameObject);
            }
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
}
