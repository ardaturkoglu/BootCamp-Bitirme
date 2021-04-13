using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChanger : MonoBehaviour
{
    StageManager stageManager;
    private void Awake()
    {
        stageManager = GameObject.FindObjectOfType<StageManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stageManager.NextStage();
        }
    }
}
