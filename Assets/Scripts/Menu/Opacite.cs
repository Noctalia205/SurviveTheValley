using UnityEngine;
using System.Collections;

public class Opacite : MonoBehaviour
{
    public GameObject imageToFade;
    public float fadeDuration = 5f;
    public float initialDelay = 2f; // Durée d'attente initiale avant de commencer la transition

    private SpriteRenderer spriteRenderer;
    private Color initialColor;
    private float timer = 0f;

    void Start()
    {
        spriteRenderer = imageToFade.GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;

        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        // Attendre pendant la durée initiale spécifiée
        yield return new WaitForSeconds(initialDelay);

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;
            float alpha = Mathf.Lerp(1f, 0f, normalizedTime);

            Color newColor = initialColor;
            newColor.a = alpha;

            spriteRenderer.color = newColor;

            yield return null;
        }

        // Assurez-vous que l'opacité soit à 0 à la fin de la coroutine
        Color finalColor = initialColor;
        finalColor.a = 0f;
        spriteRenderer.color = finalColor;
    }
}
