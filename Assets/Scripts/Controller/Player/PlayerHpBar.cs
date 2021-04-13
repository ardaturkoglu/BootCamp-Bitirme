using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpBar : MonoBehaviour
{
    public static float playerMaxHealth = 100;
    public float currentHealth;
    public bool isHit;
    public Transform bloodSpawnPosition;
    public GameObject blood;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttackHand"))
        {
            //Instantiate(EffectSet.Instance.playerDamageEffect, PlayerDestination.Instance.AttackPoint.position, Quaternion.Euler(90, 0, 0));
            currentHealth -= 10;
            isHit = true;
            Instantiate(blood, bloodSpawnPosition.position, Quaternion.identity);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyAttackHand"))
        {
            isHit = false;
        }
    }

}
