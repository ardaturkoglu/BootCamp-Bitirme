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
    Vector3 distance;
    void Start()
    {
       
        playerDestination = GetComponent<PlayerDestination>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        projectileController = GetComponent<ProjectileController>();
        Debug.Log(lookPosition);
    }

    private void Update()
    {

        if (playerDestination.enemyList.Count != 0)
        {
            distance = playerDestination.enemyList[playerDestination.targetIndex].transform.position - transform.position;
            lookPosition = playerDestination.enemyList[playerDestination.targetIndex].transform.position;
            
        }

        if (playerDestination.enemyList.Count != 0 && !playerDestination.enemyList[playerDestination.targetIndex].gameObject.GetComponent<ZombieAIController>().isEnemyDead)
        {
            Vector3 lookDirection = lookPosition - transform.position;
            lookDirection.y = 0;
            if (distance.magnitude < 5f)
            {
                transform.LookAt(transform.position + lookDirection, Vector3.up);
                FireProjectile();
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
    
    void FireProjectile()
    {
        if (playerDestination.getATarget && playerDestination.enemyList[playerDestination.targetIndex] != null)
        {
            if (Time.time >= fireCountDown)
            {
                projectileController.FireProjectile();
                fireCountDown = Time.time + 1 / fireRate;
            }
        }
    }
}
