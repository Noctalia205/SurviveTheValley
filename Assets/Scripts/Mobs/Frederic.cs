using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frederic : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 targetPosition;
    public Transform joueur;
    public float distanceToPlayer = 20;
    private Animator animator;
    public bool isActivated = false;
    public float delayTime = 5f;
    public string tagObjets;
    private bool timerStarted = false;
    private AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioFind;
    
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
            transform.position = Vector3.MoveTowards(positionActuelle, positionCible, speed * Time.deltaTime);
            isActivated= true;
            audioSource.PlayOneShot(audioFind);
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
            GameObject[] objetsAvecTag = GameObject.FindGameObjectsWithTag(tagObjets);

            if (objetsAvecTag.Length > 0)
            {
                // Choix aléatoire d'un objet dans le tableau
                int index = Random.Range(0, objetsAvecTag.Length);
                GameObject objetChoisi = objetsAvecTag[index];

                // Téléportation de cet objet
                Teleporter(objetChoisi.transform.position);
                if (audioClip != null && audioSource != null)
                {
                    audioSource.PlayOneShot(audioClip);
                }
            }
            else
            {
                Debug.LogWarning("Aucun objet avec le tag '" + tagObjets + "' trouvé !");
            }
        }
    }

    void Teleporter(Vector3 newPosition)
    {
        if (!isActivated)
        {
            transform.position = newPosition;
            Debug.Log("Téléportation effectuée vers : " + newPosition);
        }
    }
    
}
