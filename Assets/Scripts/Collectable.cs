using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private int pointValue = 5;
    private void OnCollisionEnter(Collision other) 
    {

        if(other.collider.tag == "Player")
        {

            //increase score here

            ScoreManager.instance.ChangeScore(pointValue);
            Destroy(gameObject);
        }

    }
   
}
