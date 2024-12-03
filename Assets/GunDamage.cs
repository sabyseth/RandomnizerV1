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
    public TrailRenderer BulletTrail;

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
        //var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        //bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        TrailRenderer trail = Instantiate(BulletTrail, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        StartCoroutine(SpawnTrail(trail, hitInfo));
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= Damage;
                Debug.Log("hit");
            }
        }
    }
    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit hit)
    {
        float distance = Vector3.Distance(Trail.transform.position, hit.point);
        float startingDistance = distance;
        Vector3 startposition = Trail.transform.position;

        while (distance > 0)
        {
            Trail.transform.position = Vector3.Lerp(startposition,hit.point, 1 - (distance / startingDistance));
            distance -= Time.deltaTime * bulletSpeed;

           yield return null;
        }
        Trail.transform.position = hit.point;
    }
}
