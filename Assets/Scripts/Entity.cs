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

        return health;
    }

    public bool HealthCheck()
    {
        if (health <= 0)
        {
            Die();
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void Die()
    {
    }
}
