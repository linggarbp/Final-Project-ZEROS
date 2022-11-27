using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] SpriteRenderer rend;
    int jumpCount;
    float moveDir;

    [SerializeField] LayerMask groundLayer;
    bool isGrounded;
    [SerializeField] Transform feetPosition;
    [SerializeField] float groundCheckCircle;

    [SerializeField] float KBForce;
    public float KBCounter;
    public float totalTime;
    public bool KnockFromRight;
    private void Update()
    {
        moveDir = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);
        // jump
        if (isGrounded && Input.GetKey("w"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        // flip
        if (moveDir > 0)
            rend.flipX = false;
        else if (moveDir < 0)
            rend.flipX = true;

    }
    private void FixedUpdate()
    {
        if (KBCounter <= 0)
            rb.velocity = new Vector2(moveDir * speed, rb.velocity.y);
        else
        {
            if (KnockFromRight)
                rb.velocity = new Vector2(-KBForce, KBForce);
            if (!KnockFromRight)
                rb.velocity = new Vector2(KBForce, KBForce);

            KBCounter -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != null)
            jumpCount = 0;
    }

}
