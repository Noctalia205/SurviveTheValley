using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FredericMove : MonoBehaviour
{

    public bool isActivated = false;
    public float delayTime = 5f;
    public string tagObjets;
    private bool timerStarted = false;
    public Frederic Frederic;
    
    // Start is called before the first frame update
    void Start()
    {
        bool isActivated = Frederic.isActivated;
    }

    // Update is called once per frame
    void Update()
    {
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
