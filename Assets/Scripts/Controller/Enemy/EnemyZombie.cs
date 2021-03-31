using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyZombie : EnemyBase
{
    public NavMeshAgent nvAgent;
    public GameObject player;
    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nvAgent.SetDestination(player.transform.position);
    }
}
