using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    PlayerHpBar playerHpBar;
    public Image healthImage;
    public TextMeshProUGUI currentHealthText;

    void Start()
    {
        playerHpBar = FindObjectOfType<PlayerHpBar>();
        healthImage.fillAmount = 1;
    }

    void Update()
    {
        if (playerHpBar.isHit)
        {
            
            UpdatePlayerHealth();
            healthImage.fillAmount = playerHpBar.currentHealth / PlayerHpBar.playerMaxHealth;
        }
    }

    void UpdatePlayerHealth()
    {       
        currentHealthText.text =  playerHpBar.currentHealth.ToString();       
    }

}
