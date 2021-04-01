using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestination : MonoBehaviour
{
    public static PlayerDestination Instance { get { return instance; } }
    private static PlayerDestination instance;
    public bool getATarget = false;
    float currentDistance = 0;
    float closestDistance = 100f;
    float targetDistance = 100f;
    int closeDistanceIndex = 0;
    public int targetIndex = -1;
    int previousTargetIndex = 0;
    PlayerController playerController;

    public List<GameObject> enemyList = new List<GameObject>();

    private void OnDrawGizmos()
    {
        if (getATarget)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i] == null)
                {
                    return;
                }
                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, enemyList[i].transform.position - transform.position, out hit, 20f);
                
                if (isHit)
                {
                    Gizmos.color = Color.green;
                }
                else
                {
                    Gizmos.color = Color.red;
                }
                Gizmos.DrawRay(transform.position,enemyList[i].transform.position -transform.position);
            }
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        SetDestination();
        AttackTarget();
    }

    void SetDestination()
    {
        if (enemyList.Count != 0)
        {
            
            currentDistance = 0f;
            closeDistanceIndex = 0;
            targetIndex = -1;

            for (int i = 0; i < enemyList.Count; i++)
            {
                currentDistance = Vector3.Distance(transform.position, enemyList[i].transform.position);

                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, enemyList[i].transform.position - transform.position, out hit, 10f);
                
                if (isHit )
                {

                    if (targetDistance >= currentDistance)
                    {
                        
                        targetIndex = i;
                        targetDistance = currentDistance;
                    }
                }
                if (closestDistance >= currentDistance)
                {
                    closeDistanceIndex = i;
                    closestDistance = currentDistance;
                }
            }

            if (targetIndex == -1)
            {
                targetIndex = closeDistanceIndex;
            }

            closestDistance = 100f;
            targetDistance = 100f;
            getATarget = true;

        }
    }

    void AttackTarget()
    {
        if (targetIndex == -1 || enemyList.Count == 0)
        {
            playerController.playerAnim.SetBool("IsAttacking", false);
        }
        if (getATarget && playerController.joystick.move == Vector3.zero && enemyList.Count != 0)
        {
            transform.LookAt(enemyList[targetIndex].transform);
        }
    }
}
