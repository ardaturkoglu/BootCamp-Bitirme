using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestination : MonoBehaviour
{
    private static PlayerDestination instance;
    public static PlayerDestination Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerDestination>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("PlayerDestination");
                    instance = instanceContainer.AddComponent<PlayerDestination>();
                }
            }
            return instance;
        }
    }

    public bool getATarget;
    float currentDistance;
    float closestDistance = 100f;
    float TargetDistance = 100f;
    int closeDistanceIndex = 0;
    int TargetIndex = -1;
    public LayerMask layerMask;

    public List<GameObject> EnemyList = new List<GameObject>();
    public GameObject playerBolt;
    public Transform AttackPoint;
    JoystickController joystickController;
    ProjectileController projectileController;
    PlayerController playerController;
    private void Awake()
    {
        joystickController = FindObjectOfType<JoystickController>();
        projectileController = GetComponent<ProjectileController>();
        playerController = GetComponent<PlayerController>();
    }
    private void OnDrawGizmos()
    {
        if (getATarget)
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, EnemyList[i].transform.position - transform.position, out hit, 20f, layerMask);

                if (isHit && hit.transform.CompareTag("Enemy"))
                {
                    Gizmos.color = Color.green;
                }
                else
                {
                    Gizmos.color = Color.red;
                }
                Gizmos.DrawRay(transform.position, EnemyList[i].transform.position - transform.position);
            }
        }
    }

    void Update()
    {

        SetTarget();
    }

    void SetTarget()
    {
        if (EnemyList.Count != 0)
        {
            currentDistance = 0f;
            closeDistanceIndex = 0;
            TargetIndex = -1;

            for (int i = 0; i < EnemyList.Count; i++)
            {
                currentDistance = Vector3.Distance(transform.position, EnemyList[i].transform.position);

                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, EnemyList[i].transform.position - transform.position, out hit, 20f, layerMask);

                if (isHit && hit.transform.CompareTag("Enemy"))
                {
                    if (TargetDistance >= currentDistance)
                    {
                        TargetIndex = i;
                        TargetDistance = currentDistance;
                    }
                }

                if (closestDistance >= currentDistance)
                {
                    closeDistanceIndex = i;
                    closestDistance = currentDistance;
                }

                transform.LookAt(EnemyList[TargetIndex].transform);
                
            }

            if (TargetIndex == -1)
            {
                TargetIndex = closeDistanceIndex;
            }
            closestDistance = 100f;
            TargetDistance = 100f;
            getATarget = true;
        }
    }

}
