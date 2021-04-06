using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Transform spawnProjectilePosition;
    public GameObject projectilePrefab;
    public float fireRate = 0f;
    private float fireCountDown = 0f;
   
    public List<GameObject> projectiles = new List<GameObject>();

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
        GameObject cloneProjectile = null;
        if (projectiles.Count != 0)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].gameObject.activeInHierarchy == false)
                {
                    cloneProjectile = projectiles[i];
                }
            }           
        }
        if (cloneProjectile == null)
        {
            if (Time.time >= fireCountDown)
            {
                
                
                cloneProjectile = Instantiate(projectilePrefab, spawnProjectilePosition.transform.position, spawnProjectilePosition.transform.rotation);
                //cloneProjectile.transform.parent = transform.parent;
                projectiles.Add(cloneProjectile);
               
            }
            
        }
        else
        {
            cloneProjectile.transform.localPosition = spawnProjectilePosition.transform.position;
            cloneProjectile.transform.localRotation = spawnProjectilePosition.transform.rotation;
            cloneProjectile.gameObject.SetActive(true);
        }
        //Destroy(cloneProjectile,3);
    }
}
