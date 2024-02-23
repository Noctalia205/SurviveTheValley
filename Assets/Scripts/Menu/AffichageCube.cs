using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AffichageCube : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E; // Touche pour l'interaction
    private bool isInRange = false;
    private bool interactionCooldown = false; // Cooldown d'interaction
    private float lastInteractionTime; // Temps de la dernière interaction

    public GameObject cube; // Référence au cube à faire apparaître/disparaître
    public GameObject mobSprite; // Référence au sprite de votre mob
    public GameObject blackScreen; // Référence à l'écran noir

    private AudioSource audioSource;

    // Fichier audio à jouer
    public AudioClip audioClip;

    public int nbPressionBoutons = 0;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Affecter le fichier audio à l'AudioSource
        audioSource.clip = audioClip;

        // Désactiver le sprite du mob au début
        mobSprite.SetActive(false);
        blackScreen.SetActive(false);
    }

    private void Update()
    {
        // Vérifie si le joueur est dans la zone d'interaction et si le cooldown est terminé
        if (isInRange && !interactionCooldown)
        {
            // Vérifie si la touche d'interaction a été pressée et si le temps écoulé depuis la dernière interaction est supérieur à 2 secondes
            if (Input.GetKeyDown(interactionKey) && Time.time - lastInteractionTime > 2f)
            {
                nbPressionBoutons++;
                audioSource.Play();
                if (nbPressionBoutons == 4)
                {
                    // Afficher le sprite du mob
                    mobSprite.SetActive(true);

                    // Déclencher la coroutine pour l'écran noir après 2 secondes
                    StartCoroutine(TurnOnBlackScreen());
                }
                // Lance la coroutine pour faire réapparaître et disparaître le cube
                StartCoroutine(ShowAndHideCubeRepeatedly());

                // Met à jour le temps de la dernière interaction
                lastInteractionTime = Time.time;

                // Activer le cooldown d'interaction
                interactionCooldown = true;
            }
        }

        // Vérifie si le cooldown est terminé et si le temps écoulé depuis la dernière interaction est supérieur à 2 secondes
        if (interactionCooldown && Time.time - lastInteractionTime > 2f)
        {
            // Désactive le cooldown d'interaction
            interactionCooldown = false;
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
        }

        // Réactive le cube à la fin de la séquence de répétitions
        cube.SetActive(true);
    }

    IEnumerator TurnOnBlackScreen()
    {
        yield return new WaitForSeconds(2f); // Attendre 2 secondes

        // Activer l'écran noir
        blackScreen.SetActive(true);

        // Attendre 5 secondes avant de charger la scène du menu
        yield return new WaitForSeconds(5f);

        // Charger la scène du menu
        SceneManager.LoadScene("menu");
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
