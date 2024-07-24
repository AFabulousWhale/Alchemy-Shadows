using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IDamage
{
    public GameObject parent;
    public float damageMin;
    public float damageMax;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float damage = Random.Range(damageMin, damageMax);
        Damage(damage, parent, collision.gameObject);
    }
}
