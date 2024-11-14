using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    private Transform PlayerCamera;
    public Transform bulletSpawnPoint;

    private void Start()
    {
        PlayerCamera = Camera.main.transform;
    

   }

    public void Shoot()
    {
       Ray gunRay = new Ray(bulletSpawnPoint.position, transform.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= Damage;
                Debug.Log("hit");
            }
        }
    }
}
