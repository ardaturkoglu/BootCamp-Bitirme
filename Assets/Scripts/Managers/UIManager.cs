using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    public GameObject player;
    public Image healthImage;
    public TextMeshProUGUI currentHealthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerHpBar>().isHit)
        {
            UpdatePlayerHealth();
        }
        healthImage.fillAmount = player.GetComponent<PlayerHpBar>().currentHealth / PlayerHpBar.playerMaxHealth;
    }

    void UpdatePlayerHealth()
    {
        
        currentHealthText.text =  player.GetComponent<PlayerHpBar>().currentHealth.ToString();
        
    }


}
