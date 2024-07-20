using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Weapon
{
    public GameObject bulletPrefab;

    private void Start()
    {
        BulletTest bulletScript = bulletPrefab.GetComponent<BulletTest>();

        if(!bulletScript)
        {
            bulletPrefab.AddComponent<BulletTest>();
        }

        bulletScript.parent = transform.parent.gameObject;
        bulletScript.damageMax = damageMax;
        bulletScript.damageMin = damageMin;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position,
                                          transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3
                                                (0, 700, 0));

            Destroy(bullet, 5);
        }
    }
}
