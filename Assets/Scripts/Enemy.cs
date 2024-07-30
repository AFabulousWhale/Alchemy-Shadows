using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Entity
{
    [SerializeField]
    GameObject poof;

    [SerializeField]
    Slider healthSlider;


    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public override int Damage(float damageAmount)
    {
        healthSlider.value = health;
        return base.Damage(damageAmount);
    }

    public override void Die()
    {
        KIllTracker.killTrackerREF.currentKills++;
        GameObject poofPrefab = Instantiate(poof, transform.position, Quaternion.identity);
        EnemySpawner.enemySpawnerREF.currentEnemyCount--;
        Destroy(poofPrefab, 0.3f);
        Destroy(gameObject);
    }
}
