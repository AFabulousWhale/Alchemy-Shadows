using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed       = 8f;
    private float jump_force  = 10f;
    private bool  is_grounded = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform   ground_check;
    [SerializeField] private LayerMask   ground_layer;

    Animator animator;

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(ground_check.position, 0.2f, ground_layer);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
