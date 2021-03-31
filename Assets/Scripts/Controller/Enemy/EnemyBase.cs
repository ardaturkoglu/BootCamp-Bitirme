using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public float maxHp = 10f;
    public float currentHp = 10f;

    public float damage = 10f;

    protected float playerRealizeRange = 10f;
    protected float attackRange = 5f;
    protected float attackCoolTime = 5f;
    protected float attackCoolTimeCalculate = 5f;
    protected bool canAttack = true;

    protected GameObject player;
    protected NavMeshAgent nvAgent;
    protected float distance;

    protected GameObject parentStage;

    protected Animator Anim;
    protected Rigidbody rb;

    public LayerMask layerMask;
    // Start is called before the first frame update
    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        nvAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();

        parentStage = transform.parent.transform.parent.gameObject;

        StartCoroutine(CalculationCoolTime());
    }

    protected bool CanAttackStateFun()
    {
        Vector3 targetDirection = new Vector3(player.transform.position.x - transform.position.x, 0f, player.transform.position.z - transform.position.z);
        Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDirection, out RaycastHit hit, 30f, layerMask);
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (hit.transform == null)
        {
            return false;
        }
        if (hit.transform.CompareTag("Player") && distance <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual IEnumerator CalculationCoolTime()
    {
        while (true)
        {
            yield return null;
            if (!canAttack)
            {
                attackCoolTimeCalculate -= Time.deltaTime;
                if (attackCoolTimeCalculate <= 0)
                {
                    attackCoolTimeCalculate = attackCoolTime;
                    canAttack = true;
                }
            }
        }
    }
}
