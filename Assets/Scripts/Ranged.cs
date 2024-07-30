using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Weapon
{
    public GameObject bulletPrefab;

    public int bulletSpeed = 3;
    public int shootTime = 3;
    private void Start()
    {
        Bullet bulletScript = bulletPrefab.GetComponent<Bullet>();

        if(!bulletScript)
        {
            bulletPrefab.AddComponent<Bullet>();
        }

        bulletScript.parent = transform.parent.gameObject;
        bulletScript.damageMax = damageMax;
        bulletScript.damageMin = damageMin;

        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        //detect player in range
        //shoot bullet towards player's position

        var colliders = Physics2D.OverlapCircleAll(transform.position, 15f);
        foreach (var collider in colliders)
        {
            if (collider.tag == "Player")
            {
                Vector3 lastPos = collider.transform.position;

                GameObject bullet = Instantiate(bulletPrefab, transform.position,
                                              transform.rotation);
                bullet.LeanMove(lastPos, 3f);
                Destroy(bullet, 3);
                break;
            }
        }

        yield return new WaitForSeconds(3);
        StartCoroutine(Shoot());
    }
}
