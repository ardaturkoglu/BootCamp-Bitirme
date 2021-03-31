using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeFSM : EnemyBase
{
    public enum State
    {
        Idle,
        Move,
        Attack,
    }

    public State currentState = State.Idle;

    WaitForSeconds delay500 = new WaitForSeconds(0.5f);
    WaitForSeconds delay250 = new WaitForSeconds(0.25f);
    protected void Start()
    {
        base.Start();
        parentStage = transform.parent.transform.parent.gameObject;
        Debug.Log("Start- State: " + currentState.ToString());

        StartCoroutine(FSM());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual IEnumerator FSM()
    {
        yield return null;

        while (!parentStage.GetComponent<ZoneCondition>().playerInThisRoom)
        {
            yield return delay500;
        }
        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }
}
