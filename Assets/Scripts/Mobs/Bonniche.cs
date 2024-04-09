using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonniche : MonoBehaviour
{
    public float vitesseDeplacement = 5f;
    public Vector2 targetPosition;
    public Transform joueur;
    public float distanceToPlayer = 20;
    private Animator animator;
    public bool isActivated = false;
    public float delayTime = 5f;
    public List<string> tagsObjets;
    private bool timerStarted = false;
    private AudioSource audioSource;
    public AudioClip audioClip;
    private Vector3 positionInitiale;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, joueur.position);
        if (distance <= distanceToPlayer){
            Vector3 positionActuelle = transform.position;
            Vector3 positionCible = joueur.position;
            transform.position = Vector3.MoveTowards(positionActuelle, positionCible, vitesseDeplacement * Time.deltaTime);
            isActivated= true;
            animator.SetBool("IsMoving", isActivated);
        }
        else {
            isActivated = false;
        }
        
        if (!timerStarted){
            StartCoroutine(StartTimer());
            ChoisirObjetAleatoire();
        }
    }

    IEnumerator StartTimer()
    {
        timerStarted = true;
        yield return new WaitForSeconds(delayTime);
        timerStarted = false;
    }

    void ChoisirObjetAleatoire()
    {
        if (!isActivated)
        {
            string tagChoisi = tagsObjets[Random.Range(0, tagsObjets.Count)];
            GameObject[] objetsAvecTag = GameObject.FindGameObjectsWithTag(tagChoisi);

            if (objetsAvecTag.Length > 0)
            {
                // Choix aléatoire d'un objet dans le tableau
                int index = Random.Range(0, objetsAvecTag.Length);
                GameObject objetChoisi = objetsAvecTag[index];

                // Déplacer l'objet vers la position de l'objet choisi
                positionInitiale = transform.position;
                Vector3 positionFinale = objetChoisi.transform.position;
                StartCoroutine(DeplacerObjet(positionFinale));
                if (audioClip != null && audioSource != null)
                {
                    audioSource.PlayOneShot(audioClip);
                }
                }
            else
            {
                Debug.LogWarning("Aucun objet avec le tag '" + tagChoisi + "' trouvé !");
            }
        }
    }

    IEnumerator DeplacerObjet(Vector3 positionFinale)
    {
        float distanceTotale = Vector3.Distance(positionInitiale, positionFinale);
        float tempsDeDeplacement = distanceTotale / vitesseDeplacement;
        float tempsPasse = 0f;

        while (tempsPasse < tempsDeDeplacement)
        {
            tempsPasse += Time.deltaTime;
            float ratio = Mathf.Clamp01(tempsPasse / tempsDeDeplacement);
            transform.position = Vector3.Lerp(positionInitiale, positionFinale, ratio);
            yield return null;
        }

        transform.position = positionFinale;
        Debug.Log("Déplacement terminé !");
    }
    
}
