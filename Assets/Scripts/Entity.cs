using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : IDamage
{
    public float health;
    public float maxHealth;

    public bool isDead;

    public virtual int Damage(float damageAmount)
    {
        health -= damageAmount;

        health = Mathf.Clamp(health, 0, maxHealth);

        isDead = HealthCheck();

        return (int)health;
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
