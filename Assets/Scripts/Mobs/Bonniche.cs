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
    public Transform[] waypoints;
    private AudioSource audioSource;
    public AudioClip audioClip;
    
    private Vector3 positionInitiale;
    private int currentWaypointIndex = 0;
    
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
            if (audioClip != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioClip);
            }
            animator.SetBool("IsMoving", isActivated);
        }
        else {
            isActivated = false;
        }
        
        

        if (currentWaypointIndex < waypoints.Length)
        {
            // Déplacez l'objet vers la balise actuelle
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, vitesseDeplacement * Time.deltaTime);

            // Si l'objet est proche de la balise actuelle, passez à la suivante
            if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex++;

                // Si nous avons atteint la dernière balise, réinitialisez l'indice pour boucler
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
        } 
    }

    
}
