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
    public bool isEnemyDead;
    public bool touchTarget;
    public Transform blackBloodSpawnPosition;
    public GameObject blackBlood;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
 
    }
    private void Update()
    {
        if (target.GetComponent<PlayerDestination>().getATarget && !isEnemyDead && !touchTarget)
        {
            CheckPlayerInZone();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            touchTarget = true;
            agent.isStopped = true;
            enemyAnimator.SetBool("Attacking", true);
            enemyAnimator.SetBool("Running", false);
        }
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Hello");
            //isEnemyDead = true;
            //agent.isStopped = true;
            Instantiate(blackBlood, blackBloodSpawnPosition.position, Quaternion.identity);
            //enemyAnimator.SetBool("Attacking", false);
            //enemyAnimator.SetBool("Idle", false);
            //enemyAnimator.SetBool("Running", false);
            //enemyAnimator.SetBool("Dead", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            touchTarget = false;
            agent.isStopped = false;
            enemyAnimator.SetBool("Attacking", false);

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyAnimator.SetBool("Attacking", true);
            touchTarget = true;
            if (!isEnemyDead)
            {
                //enemyAnimator.SetBool("Attacking", true);
            }
        }
    }

    void CheckPlayerInZone()
    {
        if (!isEnemyDead)
        {
            agent.SetDestination(target.position);
            if (!touchTarget)
            {
                enemyAnimator.SetBool("Running", true);
                enemyAnimator.SetBool("Attacking", false);
            }
            else
            {
                enemyAnimator.SetBool("Running", false);
            }
            agent.speed = runSpeed;
        }              
    }
}
