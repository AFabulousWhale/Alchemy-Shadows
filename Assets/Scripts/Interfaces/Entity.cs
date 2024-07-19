using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public virtual float Damage(float damageAmount)
    {
        health -= damageAmount;

        health = Mathf.Clamp(health, 0, maxHealth);

        Debug.Log(health);

        if(health <= 0)
        {
            Die();
        }

        return health;
    }

    public virtual void Die()
    {

    }
}
