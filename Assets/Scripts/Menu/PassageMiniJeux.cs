using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassageMiniJeux : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowImageForDuration(9f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShowImageForDuration(float duration)
    {
        // Attendre pendant la durée spécifiée
        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene("MiniJeux1");

    }
}
