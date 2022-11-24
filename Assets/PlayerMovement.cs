using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    Rigidbody2D rb;
    Vector2 moveDir;
    int jumpCount;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var jump = Input.GetAxis("Jump") * jumpHeight * Time.deltaTime;

        // move
        transform.Translate(new Vector2(moveX, 0));

        // jump
        if (Input.GetKeyDown("w"))
        {
            if (jumpCount >= 2)
                return;

            jumpCount++;
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != null)
            jumpCount = 0;
    }

}
