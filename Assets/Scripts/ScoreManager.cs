using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;


    public int score = 0;
    void Awake() 
    {
        if(!instance)
        {
            instance = this;  
        }
          
    }
    void Update() 
    {
        
    }

    public void ChangeScore(int value) 
    {
        score += value;
        Debug.Log(score);    
    }
}
