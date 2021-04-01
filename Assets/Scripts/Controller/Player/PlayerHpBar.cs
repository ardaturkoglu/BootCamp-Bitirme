using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpBar : MonoBehaviour
{
    public static float playerMaxHealth = 100;
    public float currentHealth;
    public bool isHit;
    private void Start()
    {
        currentHealth = playerMaxHealth;
    }
    private void Update()
    {
        if (isHit && currentHealth <= 0)
        {
            //TODO dead anim
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyAttackHand")
        {
            //Instantiate(EffectSet.Instance.playerDamageEffect, PlayerDestination.Instance.AttackPoint.position, Quaternion.Euler(90, 0, 0));
            currentHealth -= 10;
            isHit = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            isHit = false;
            
        }
    }

}
