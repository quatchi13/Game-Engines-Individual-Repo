using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
   public static HealthManager instance;

    public TMP_Text scoreText;
    public int health = 3;
    void Awake() 
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(instance);  
        }
          
    }
    void Update() 
    {
        scoreText.text =  "Health X" + health.ToString();
    
        if(health <= 0)
        {
            SceneControl.instance.GotoScene(3);
            health = 3;
        }
    }

    public void ChangeHealth(int value) 
    {
        health += value;
        Debug.Log(health);    
    }
}
