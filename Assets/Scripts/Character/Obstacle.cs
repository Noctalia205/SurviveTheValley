using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test1 : MonoBehaviour
{
    public float interactionRadius = 2f; // Rayon de proximité pour interagir avec l'objet
    public KeyCode interactionKey = KeyCode.E; // Touche pour l'interaction
    private bool isInRange = false;

    public int nbItems = 0; //nb d'items

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactionKey))
        {
            if (gameObject.CompareTag("item")){
                nbItems += 1; 
                Debug.Log(nbItems);
            }
            Debug.Log("GIROUD NTM");
            if (nbItems == 1) {
                SceneManager.LoadScene("gameOver");
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

