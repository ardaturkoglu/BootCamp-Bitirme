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
}
