using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frederic : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 targetPosition;
    public Transform joueur;
    public float distanceToPlayer = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, joueur.position);
        if (distance <= distanceToPlayer){
            Vector3 positionActuelle = transform.position;
            Vector3 positionCible = joueur.position;
            transform.position = Vector3.MoveTowards(positionActuelle, positionCible, speed * Time.deltaTime);
        }
        
    }
    
}
