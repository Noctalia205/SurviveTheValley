using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screamer : MonoBehaviour
{
    public Transform imageTransform;
    public float targetScale = 2f;
    public float duration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScaleCoroutine());
        StartCoroutine(TimeBeforeGameOver(3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ScaleCoroutine()
    {
        float timer = 0f;
        Vector3 startScale = imageTransform.localScale;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            imageTransform.localScale = Vector3.Lerp(startScale, Vector3.one * targetScale, t);
            yield return null;
        }

        imageTransform.localScale = Vector3.one * targetScale; // Assurez-vous que l'image atteint la taille cible précisément.
    }

    IEnumerator TimeBeforeGameOver(float duree)
    {
        // Attendre pendant la durée spécifiée
        yield return new WaitForSeconds(duree);

        SceneManager.LoadScene("gameOver");

    }
}
