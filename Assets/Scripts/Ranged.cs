using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Weapon
{
    public GameObject bulletPrefab;

    Animator anim;

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

        anim = transform.parent.gameObject.GetComponent<Animator>();

        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        //detect player in range
        //shoot bullet towards player's position

        anim.StopPlayback();
        anim.Play("Shoot");

        var colliders = Physics2D.OverlapCircleAll(transform.position, 15f);
        foreach (var collider in colliders)
        {
            if (collider.tag == "Player")
            {
                Vector3 lastPos = collider.transform.position;

                GameObject bullet = Instantiate(bulletPrefab, transform.position,
                                              transform.rotation);
                bullet.LeanMove(lastPos, shootTime);
                Destroy(bullet, bulletSpeed);
                break;
            }
        }
        anim.Play("Idle");
        yield return new WaitForSeconds(shootTime);
        StartCoroutine(Shoot());
    }
}
