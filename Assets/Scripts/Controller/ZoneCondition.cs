using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCondition : MonoBehaviour
{
    StageManager stageManager;
    List<GameObject> EnemyListInRoom = new List<GameObject>();
    public bool playerInThisRoom;
    public bool isClearRoom;
    public int prisonerCount;
    private void Awake()
    {
        stageManager = GameObject.FindObjectOfType<StageManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInThisRoom)
        {
            if (EnemyListInRoom.Count <= 0 && !isClearRoom && prisonerCount == 0)
            {
                isClearRoom = true;
                Debug.Log("Clear");
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInThisRoom = true;
            PlayerDestination.Instance.enemyList = new List<GameObject> (EnemyListInRoom);
            Debug.Log("Enter New Room! Mob Count: " + PlayerDestination.Instance.enemyList.Count);
            Debug.Log("Player ENter new room");
        }
        if (other.CompareTag("Enemy"))
        {
            EnemyListInRoom.Add(other.gameObject);
            Debug.Log("Enemy name: " + other.gameObject.name);
        }
        if (other.CompareTag("Prisoner"))
        {
            prisonerCount++;
        }
        if (other.CompareTag("NextStage"))
        {
            
            stageManager.NextStage();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInThisRoom = false;
            PlayerDestination.Instance.enemyList.Clear();
            Debug.Log("Player Exit");
        }

        if (other.CompareTag("Enemy"))
        {
            EnemyListInRoom.Remove(other.gameObject);
        }

        if (other.CompareTag("Prisoner"))
        {
            prisonerCount--;
        }
    }
}
