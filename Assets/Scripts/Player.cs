using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player: Entity
{
    [SerializeField]
    TextMeshProUGUI healthUI;

    public bool isDead;

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

        isDead = HealthCheck();

        return health;
    }

    public override void Die()
    {
        //player death stuff
    }
}
