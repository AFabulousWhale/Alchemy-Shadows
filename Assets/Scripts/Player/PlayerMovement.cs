using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] float speed       = 8f;
    [SerializeField] float jump_force  = 10f;
    private bool  is_grounded = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform   ground_check;
    [SerializeField] private LayerMask   ground_layer;

    Animator animator;
    SpriteRenderer sprite;
    BoxCollider2D collider;

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(ground_check.position, 0.2f, ground_layer);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("X", horizontal);

        if(horizontal == -1)
        {
            sprite.flipX = true;
            collider.offset = new Vector2(0.43f, -0.02074242f);
        }

        if (horizontal == 1)
        {
            sprite.flipX = false;
            collider.offset = new Vector2(-0.4126931f, -0.02074242f);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .05f);
        }
    }
}
