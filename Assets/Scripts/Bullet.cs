using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IDamage
{
    public GameObject parent;
    public float damageMin;
    public float damageMax;

    [SerializeField]
    bool isRanged;

    private void Update()
    {
        Rotate(120);
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
            if (isRanged)
            {
                Destroy(gameObject);
            }
        }

        if (collision.tag != "Enemy" && collision.tag != "Bullet" && isRanged)
        {
            Destroy(gameObject);
        }
    }
}
