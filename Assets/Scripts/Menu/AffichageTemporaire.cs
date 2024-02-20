using UnityEngine;
using System.Collections;

public class AffichageTemporaire : MonoBehaviour
{
    public GameObject imageToHide;

    void Start()
    {
        StartCoroutine(ShowImageForDuration(2f));
    }

    IEnumerator ShowImageForDuration(float duration)
    {
        // Activer l'image
        if (imageToHide != null)
        {
            imageToHide.SetActive(true);
        }

        // Attendre pendant la durée spécifiée
        yield return new WaitForSeconds(duration);

        // Début de la transition de masquage progressif
        StartCoroutine(HideImage());
    }

    IEnumerator HideImage()
    {
        // Définir la durée totale de la transition de masquage
        float transitionDuration = 3f; // Par exemple, 3 secondes

        // Temps écoulé depuis le début de la transition
        float elapsedTime = 0f;

        // Boucle de masquage progressif
        while (elapsedTime < transitionDuration)
        {
            // Calculer le rapport d'opacité en fonction du temps écoulé
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / transitionDuration);

            // Appliquer l'opacité à l'image
            SetImageAlpha(alpha);

            // Mettre à jour le temps écoulé
            elapsedTime += Time.deltaTime;

            // Attendre le prochain frame
            yield return null;
        }

        // Assurer que l'opacité soit bien à zéro à la fin de la transition
        SetImageAlpha(0f);
    }

    // Méthode pour définir l'opacité de l'image
    private void SetImageAlpha(float alpha)
    {
        if (imageToHide != null)
        {
            // Obtenir le composant de rendu de l'image
            Renderer renderer = imageToHide.GetComponent<Renderer>();

            // Vérifier si le composant de rendu existe et est un sprite renderer
            if (renderer != null && renderer is SpriteRenderer)
            {
                // Modifier l'opacité du sprite renderer
                Color color = renderer.material.color;
                color.a = alpha;
                renderer.material.color = color;
            }
            else
            {
                Debug.LogWarning("Le GameObject n'a pas de composant SpriteRenderer.");
            }
        }
    }
}
