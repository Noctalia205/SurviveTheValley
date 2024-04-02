using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassageMiniJeux : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        StartCoroutine(ShowImageForDuration(9f));
=======
        StartCoroutine(ShowImageForDuration(5f));
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======

>>>>>>> Stashed changes
    }
    IEnumerator ShowImageForDuration(float duration)
    {
        // Attendre pendant la durée spécifiée
        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene("MiniJeux1");

    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
