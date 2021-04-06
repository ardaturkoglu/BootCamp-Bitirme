using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public JoystickController joystick;
    public float speed = 4;
    public GameObject gun;
    public float fireRate = 0f;
    private float fireCountDown = 0f;
    Animator playerAnim;
    Rigidbody playerRigidbody;
    PlayerDestination playerDestination;
    Vector3 lookPosition;
    ProjectileController projectileController;
    void Start()
    {
       
        playerDestination = GetComponent<PlayerDestination>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        projectileController = GetComponent<ProjectileController>();
    }

    private void Update()
    {
        if (playerDestination.enemyList.Count != 0)
        {
           lookPosition = playerDestination.enemyList[playerDestination.targetIndex].transform.position;
        }
       
        
        Vector3 lookDirection = lookPosition - transform.position;
        lookDirection.y = 0;

        transform.LookAt(transform.position + lookDirection, Vector3.up);
        if (playerDestination.getATarget && playerDestination.enemyList[playerDestination.targetIndex] != null)
        {
            if (Time.time >= fireCountDown)
            {
                projectileController.FireProjectile();
                fireCountDown = Time.time + 1 / fireRate;
            }
        }
    }
    void FixedUpdate()
    {
        float horizontal = joystick.move.x;
        float vertical = joystick.move.z;

        
        playerRigidbody.AddForce(joystick.move * speed / Time.fixedDeltaTime);
        if (joystick.move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(joystick.move), 5 * Time.deltaTime);
        }
        
        
        playerAnim.SetFloat("Forward", vertical,0.1f,Time.fixedDeltaTime);
        playerAnim.SetFloat("Turn", horizontal, 0.1f, Time.fixedDeltaTime);

    }
    
}
