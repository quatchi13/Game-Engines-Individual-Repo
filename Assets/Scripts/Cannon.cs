using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
   [SerializeField]
   private float reloadTime;

   [SerializeField]
   private GameObject projectile;

   [SerializeField]
   private Transform projectileSpawn;

   private float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= reloadTime)
        {
            Shoot();
            currentTime = 0;
        }
    }

    public void Shoot()
    {
        Rigidbody bulletRb = Instantiate(projectile, projectileSpawn.position , new Quaternion(0.5f,0.0f, 0.0f, 0.5f)).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 1.0f, ForceMode.Impulse);
    }
}
