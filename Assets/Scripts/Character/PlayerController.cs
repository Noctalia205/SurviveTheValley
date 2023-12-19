using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update

    public float vitesseDeplacement = 5f;
    private Rigidbody2D rb;
    private Vector3 echelleInitiale;


    void Start()
    {
        echelleInitiale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Déplacement
        float deplacement = vitesseDeplacement * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * deplacement);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * deplacement);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * deplacement);

            transform.localScale = new Vector3(echelleInitiale.x, echelleInitiale.y, echelleInitiale.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * deplacement);
            transform.localScale = new Vector3(-echelleInitiale.x, echelleInitiale.y, echelleInitiale.z);
        }


    }


}