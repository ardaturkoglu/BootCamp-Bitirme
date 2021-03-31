using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAIController : MonoBehaviour
{
    public float zombieSpeed;
    public NavMeshAgent agent = null;

    internal Transform target = null;

    private void Start()
    {
        agent.SetDestination(target.position);
        agent.speed = zombieSpeed;
    }
}
