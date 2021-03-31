using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StageManager : MonoBehaviour
{
    //[Serializable]
    //public class StartPositionArray
    //{
    //    public List<Transform> startPosition = new List<Transform>();
    //}
    //public StartPositionArray[] startPositionArrays;
    //
    public GameObject player;
    public Transform playerSpawnPosition;
    //public Transform startPoint;
    public int currentStage = 0;
    int lastStage = 5;
    CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        cameraController = FindObjectOfType<CameraController>();
    }

    public void NextStage()
    {
        Debug.Log("sıradaki stage");
        player.transform.position = playerSpawnPosition.position;
        
        cameraController.CameraNextStage();
    }
}

