using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public int score = 0;
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
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text =  "Score: " + score.ToString();
    
    }

    public void ChangeScore(int value) 
    {
        score += value;
        Debug.Log(score);    
    }
}
