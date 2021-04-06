using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private float offSetY = 15;
    private float offSetZ = -7;

    Vector3 cameraPosition;

    void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x;
        cameraPosition.y = player.transform.position.y + offSetY; 
        cameraPosition.z = player.transform.position.z + offSetZ;

        transform.position = cameraPosition;
    }

    public void CameraNextStage()
    {
        cameraPosition.x = player.transform.position.x;
    }
}
