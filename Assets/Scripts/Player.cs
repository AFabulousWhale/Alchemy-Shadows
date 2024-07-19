using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player: Entity
{
    [SerializeField]
    TextMeshProUGUI healthUI;

    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Damage(5);
        }
    }

    public override float Damage(float damageAmount)
    {
        healthUI.text = ($"Health: {base.Damage(damageAmount)}");
        return health;
    }
}
