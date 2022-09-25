using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Player"))
        {
            HealthManager.instance.ChangeHealth(-1);
            ScoreManager.instance.ChangeScore(-50);
            Destroy(gameObject);
        }
    }
}
