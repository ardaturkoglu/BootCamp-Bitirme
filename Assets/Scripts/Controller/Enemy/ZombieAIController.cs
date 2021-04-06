using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAIController : MonoBehaviour
{

    [SerializeField]
    private NavMeshAgent agent = null;
    [SerializeField]
    private Animator enemyAnimator = null;
    [SerializeField]
    private float runSpeed = 0f;
    private Transform target = null;
    public bool isPlayerActiveInZone;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (isPlayerActiveInZone)
        {
            agent.SetDestination(target.position);
            enemyAnimator.SetBool("Running", true);
            agent.speed = runSpeed;
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.isStopped = true;
            enemyAnimator.SetBool("Running", false);
            enemyAnimator.SetBool("Attacking", true);
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        enemyAnimator.SetBool("Idle", true);
    //    }
    //}
}
