using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Transform spawnProjectilePosition;
    public float projectileSpeed;
    public GameObject projectilePrefab;
    public float fireRate = 0f;
    private float fireCountDown = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (Time.time >= fireCountDown)
            {
                FireProjectile();
                fireCountDown = Time.time + 1 / fireRate;
            }
        }
    }

    public void FireProjectile()
    {
        GameObject cloneProjectile = Instantiate(projectilePrefab, spawnProjectilePosition.transform.position, spawnProjectilePosition.transform.rotation);
        Destroy(cloneProjectile,3);
    }
}
