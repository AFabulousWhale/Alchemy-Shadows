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

    [SerializeField]
    GameObject death;

    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        healthUI.text = $"Health: {health}";
    }

    private void Update()
    {
        if (KIllTracker.killTrackerREF.progression != KIllTracker.Progression.stage3)
        {
            enemies.text = ($"Enemies Left: {KIllTracker.killTrackerREF.currntNeededKills - KIllTracker.killTrackerREF.currentKills}");
        }


        if (Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }
        else
        {
            anim.SetBool("startAttack", false);
        }
    }

    public override int Damage(float damageAmount)
    {
        healthUI.text = ($"Health: {base.Damage(damageAmount)}");

        return (int)health;
    }

    public override void Die()
    {
        GetComponent<PlayerMovement>().enabled = false;
        Transitions.instance.FadeIn();
        death.SetActive(true);
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
