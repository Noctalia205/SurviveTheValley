using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreamerDeath : MonoBehaviour
{
    public AudioClip deathScreamAudioClip; // AudioClip pour le cri de mort 

    void Start()
    {
        // Lancer la coroutine pour attendre 2 secondes avant de charger la scène "gameOver"
        StartCoroutine(LoadGameOverScene());
    }

    IEnumerator LoadGameOverScene()
    {
        // Attendre 2 secondes
        yield return new WaitForSeconds(2f);

        // Charger la scène "gameOver"
        SceneManager.LoadScene("gameOver");
    }
}
