﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController playerCharacterController;
    JoystickController joystick;
    public float speed;
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacterController = GetComponent<CharacterController>();
        joystick = FindObjectOfType<JoystickController>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (joystick.move != Vector3.zero)
        {
            transform.rotation =  Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(joystick.move), 5 * Time.deltaTime);
            playerCharacterController.SimpleMove(joystick.move * speed * Time.deltaTime);

            if (playerAnim.GetBool("IsRunning") == false)
            {
                playerAnim.SetBool("IsRunning", true);
            }
            if (playerAnim.GetBool("IsAttacking") == true)
            {
                playerAnim.SetBool("IsAttacking", false);
            }
        }
        else
        {
            if (playerAnim.GetBool("IsRunning") == true)
            {
                playerAnim.SetBool("IsRunning", false);
            }
            if (playerAnim.GetBool("IsAttacking") == false)
            {
                playerAnim.SetBool("IsAttacking", true);
            }
        }
    }
}