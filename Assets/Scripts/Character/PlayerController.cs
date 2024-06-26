using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float vitesseDeplacement = 5f;
    private Rigidbody2D rb;
    private Vector3 echelleInitiale;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isMoving = false;
    private bool jeuEnPause = false;
    private AudioSource audioSource;
    public AudioClip audioClip;
    public int nbItems = 0;

    

    void Start()
    {
        echelleInitiale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        CheckMovement();

         StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        // Désactiver le mouvement du joueur
        enabled = false;

        // Attendre 2 secondes
        yield return new WaitForSeconds(4f);

        // Activer le mouvement du joueur
        enabled = true;
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
        CheckMovement();

        if (nbItems >= 3)
        {
            SceneManager.LoadScene("Victory"); // Charge la scène "Victory"
        }
    }
    void CheckMovement()
    {
        // Si l'objet est en mouvement et que l'audio n'est pas déjà en train de jouer
        if (isMoving && !audioSource.isPlaying)
        {
            // Jouer l'audio
            audioSource.Play();
        }
        // Si l'objet n'est pas en mouvement et que l'audio est en train de jouer
        else if (!isMoving && audioSource.isPlaying)
        {
            // Arrêter l'audio
            audioSource.Stop();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.CompareTag("interactuable") )
        {
            SceneManager.LoadScene("gameOver");
        }
        
        if (collision.gameObject.CompareTag("Mob"))
        {
            SceneManager.LoadScene("screemer");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si le joueur entre en collision avec cet obstacle
        if (other.CompareTag("interactuable"))
        {
            // Faites quelque chose lorsque le joueur entre en collision avec cet obstacle
            Debug.Log("Le joueur a rencontré un obstacle !");
        }
    }

}
