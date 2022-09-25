using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
   [SerializeField]
    private int healthValue;
    private void OnCollisionEnter(Collision other) 
    {

        if(other.collider.tag == "Player")
        {

            //increase score here

            HealthManager.instance.ChangeHealth(healthValue);
            Destroy(gameObject);
        }

    }
}
