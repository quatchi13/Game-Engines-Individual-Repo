using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{

    public static SceneControl instance;


    void Awake() 
    {
        if(!instance)
        {
            instance = this; 
            DontDestroyOnLoad(instance); 
        }
          
    }

    public void NextScene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GotoScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("You Quit");
    }
}
