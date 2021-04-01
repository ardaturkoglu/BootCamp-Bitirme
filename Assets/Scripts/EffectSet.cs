using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSet : MonoBehaviour
{
    private static EffectSet instance;
    public static EffectSet Instance
    {
        get
        {
            if (instance == null )
            {
                instance = FindObjectOfType<EffectSet>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("EffectSet");
                    instance = instanceContainer.AddComponent<EffectSet>();
                }
            }
            return instance;
        }
    }

    [Header("Monster")]
    public GameObject zombieAttackEffect;
    public GameObject zombieDamageEffect;

    [Header("Player")]
    public GameObject playerAttackEffect;
    public GameObject playerDamageEffect;
}
