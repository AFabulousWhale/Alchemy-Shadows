using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    //rabbit bounces towards player
    //attacks when near

    public int shootTime = 3;

    Transform parent;
    Rigidbody2D rb;

    [SerializeField]
    GameObject bullet;
    private void Start()
    {
        parent = transform.parent;
        rb = parent.GetComponent<Rigidbody2D>();

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (!bulletScript)
        {
            bullet.AddComponent<Bullet>();
        }

        bulletScript.parent = transform.parent.gameObject;
        bulletScript.damageMax = damageMax;
        bulletScript.damageMin = damageMin;

        StartCoroutine(JumpAttack());
    }

    IEnumerator JumpAttack()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 3f);
        foreach (var collider in colliders)
        {
            if (collider.tag == "Player")
            {
                rb.AddRelativeForce(Vector3.up);
                break;
            }
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(JumpAttack());
    }
}
