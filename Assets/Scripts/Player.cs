using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player: Entity
{
    [SerializeField]
    TextMeshProUGUI healthUI;

    Animator anim;

    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    int minDamage = 5;
    int maxDamage = 10;

    SpriteRenderer sprite;

    [SerializeField]
    TextMeshProUGUI enemies;

    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        enemies.text = ($"Enemies Left: {KIllTracker.killTrackerREF.currntNeededKills - KIllTracker.killTrackerREF.currentKills}");
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }
        else
        {
            anim.SetBool("startAttack", false);
        }
    }

    public override float Damage(float damageAmount)
    {
        healthUI.text = ($"Health: {base.Damage(damageAmount)}");

        return health;
    }

    public override void Die()
    {
        //player death stuff
    }

    public void Attack()
    {
        Vector2 direction;
        if(sprite.flipX)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }

        anim.SetBool("startAttack", true);

        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, direction, 2f);

        Debug.DrawRay(transform.position, direction, Color.green);

        // If it hits enemy
        if (hit.collider.tag == "Enemy")
        {
            int damage = Random.Range(minDamage, maxDamage);
            hit.collider.GetComponent<Entity>().Damage(damage);
        }
    }
}
