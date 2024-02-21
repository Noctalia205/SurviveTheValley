using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    // Start is called before the first frame update

    public float vitesseDeplacement = 5f;
    private Rigidbody2D rb;
    private Vector3 echelleInitiale;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isMoving = false;
    private bool jeuEnPause = false;
    

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            jeuEnPause = !jeuEnPause;

            if (jeuEnPause)
            {
                AfficherPause();
                
            }
            else
            {
                ReprendreJeu();
                Time.timeScale = 1;
            }
        }

        void AfficherPause()
        {
            Time.timeScale = 0; // Mettre en pause le temps
            SceneManager.LoadScene("pause", LoadSceneMode.Additive);
        }

        void ReprendreJeu()
        {
            
            Time.timeScale = 1; // Rétablir le temps
            jeuEnPause = false;

            SceneManager.UnloadSceneAsync("pause");
            GameObject menuPause = GameObject.Find("MenuPause");
            if (menuPause != null)
            {
                menuPause.SetActive(false);
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Mob"))
        {
            SceneManager.LoadScene("gameOver");
        }
    }
}
