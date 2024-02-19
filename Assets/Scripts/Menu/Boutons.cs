using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boutons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jouer()
    {
        SceneManager.LoadScene("game");
    }

    public void Resume()
    {
        SceneManager.UnloadSceneAsync("pause");
    }

    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Help()
    {
        SceneManager.LoadScene("help");
    }

    public void Retour()
    {
        SceneManager.LoadScene("menu");
    }
}
