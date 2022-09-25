using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private int pointValue;
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
