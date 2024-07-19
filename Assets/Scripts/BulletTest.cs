using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : IDamage
{
    public GameObject parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(50, this.gameObject, collision.gameObject);
    }
}
