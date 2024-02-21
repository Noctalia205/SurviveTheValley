using UnityEngine;

public class test1 : MonoBehaviour
{
    public float interactionRadius = 2f; // Rayon de proximité pour interagir avec l'objet
    public KeyCode interactionKey = KeyCode.E; // Touche pour l'interaction
    private bool isInRange = false;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactionKey))
        {
            Debug.Log("GIROUD NTM");
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

