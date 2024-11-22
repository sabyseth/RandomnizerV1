using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    public float Damage;
    public Recoil RecoilObject;
    public float BulletRange;
    public ParticleSystem MuzzleFlash;
    private Transform PlayerCamera;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    private void Start()
    {
        PlayerCamera = Camera.main.transform;
    

   }

    public void Shoot()
    {
       Ray gunRay = new Ray(bulletSpawnPoint.position, transform.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
        MuzzleFlash.Play();
        RecoilObject.recoil += 0.005f;
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= Damage;
                Debug.Log("hit");
            }
        }
    }
}
