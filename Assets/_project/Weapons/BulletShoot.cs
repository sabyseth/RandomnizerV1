using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
 
public class BulletShoot : NetworkBehaviour
{
    public float life = 3;

    
 
    void Awake()
    {
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter(Collision collision)
  {
    Destroy(gameObject);
  }

}

