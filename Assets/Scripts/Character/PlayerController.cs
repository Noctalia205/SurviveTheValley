using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update

    public float vitesseDeplacement = 5f;
    private Rigidbody2D rb;
    private Vector3 echelleInitiale;
    public Sprite idleSprite;
    public Sprite movingSprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isMoving = false;
    

    void Start()
    {
        echelleInitiale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Déplacement
        float deplacement = vitesseDeplacement * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            transform.Translate(Vector3.up * deplacement);
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;
            transform.Translate(Vector3.down * deplacement);
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            transform.Translate(Vector2.left * deplacement);
            transform.localScale = new Vector3(echelleInitiale.x, echelleInitiale.y, echelleInitiale.z);
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            transform.Translate(Vector2.right * deplacement);
            transform.localScale = new Vector3(-echelleInitiale.x, echelleInitiale.y, echelleInitiale.z);
            
        }
        else
        {
            isMoving = false;
        }
        //Idle Animation
        animator.SetBool("IsMoving", isMoving);

    }

    
}
