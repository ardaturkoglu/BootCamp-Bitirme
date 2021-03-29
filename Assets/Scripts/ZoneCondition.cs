using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCondition : MonoBehaviour
{
    List<GameObject> EnemyListInRoom = new List<GameObject>();
    public bool playerInThisRoom;
    public bool isClearRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInThisRoom)
        {
            if (EnemyListInRoom.Count <= 0 && !isClearRoom)
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
            PlayerDestination.Instance.EnemyList = new List<GameObject> (EnemyListInRoom);
            Debug.Log("Enter New Room! Mob Count: " + PlayerDestination.Instance.EnemyList.Count);
            Debug.Log("Player ENter new room");
        }
        if (other.CompareTag("Enemy"))
        {
            EnemyListInRoom.Add(other.gameObject);
            Debug.Log("Enemy name: " + other.gameObject.name);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInThisRoom = false;
            Debug.Log("Player Exit");
        }

        if (other.CompareTag("Enemy"))
        {
            EnemyListInRoom.Remove(other.gameObject);
        }
    }
}
