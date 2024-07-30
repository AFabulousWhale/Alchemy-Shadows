using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IDamage
{
    public GameObject parent;
    public float damageMin;
    public float damageMax;

    private void Update()
    {
        Rotate(360);
    }

    public void Rotate(float rotationAmount)
    {
        if (!LeanTween.isTweening(this.gameObject))
        {
            LeanTween.rotateZ(this.gameObject, (this.gameObject.transform.eulerAngles.z + rotationAmount), 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            float damage = Random.Range(damageMin, damageMax);
            Damage(damage, parent, collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag != "Enemy" && collision.tag != "Bullet")
        {
            Debug.Log(collision.tag);
            Destroy(gameObject);
        }
    }
}
