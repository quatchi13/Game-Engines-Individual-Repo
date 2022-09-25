using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefyBoi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -1.0f)
        {
            SceneControl.instance.NextScene();
        }
    }

    private void OnCollisionEnter(Collision other) 
    
    {
        if(other.collider.CompareTag("bullet"))
        {
            ScoreManager.instance.ChangeScore(10);
            Destroy(other.gameObject);
        }    
    }
}
