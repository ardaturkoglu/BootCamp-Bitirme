using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed = 0f;
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * projectileSpeed, Space.Self);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            transform.Translate(Vector3.zero);
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
        if (other.transform.CompareTag("Wall"))
        {
            transform.Translate(Vector3.zero);
            gameObject.SetActive(false);
        }
    }
}
