using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("PLAYER STATS")]
    public int maxHealth = 10;
    public int health;
    public int lastHealth;
    public static bool isAlive;
    bool onMission;
    Restaurant newMission;

    Vector3 respawnPoint;

    //PLAYER MOVEMENT
    [Header("PLAYER MOVEMENT")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    int jumpCount;
    float moveDir;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;


    [SerializeField] Transform feetPosition;
    [SerializeField] float groundCheckCircle;

    [Header("KNOCK BACK")]
    public float KBForce;
    public float KBCounter;
    public float totalTime;
    public bool KnockFromRight;

    [Header("ANIMATION")]
    [SerializeField] SpriteRenderer rend;
    [SerializeField] Animator animator;

    private void Start()
    {
        respawnPoint = transform.position;
        health = maxHealth;
    }
    private void Update()
    {
        if (Input.GetKey("e") && onMission)
        {
            newMission.TakeMission();
        }

        if (health <= 0)
        {
            Die();
        }

        if (lastHealth != health)
            Debug.Log(health);

        lastHealth = health;

        //PLAYER MOVEMENT
        moveDir = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);
        // jump
        if (isGrounded && Input.GetKey("w"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        animator.SetBool("isJumping", !isGrounded);

        // flip
        if (moveDir > 0)
            rend.flipX = false;
        else if (moveDir < 0)
            rend.flipX = true;

        if (moveDir != 0)
            animator.SetBool("isMove", true);
        else
            animator.SetBool("isMove", false);


    }
    private void FixedUpdate()
    {
        if (KBCounter <= 0)
            rb.velocity = new Vector2(moveDir * speed, rb.velocity.y);
        else
        {
            if (KnockFromRight)
                rb.velocity = new Vector2(-KBForce * 3, KBForce);
            if (!KnockFromRight)
                rb.velocity = new Vector2(KBForce * 3, KBForce);

            KBCounter -= Time.deltaTime;
        }
    }

    void Attack()
    {

    }

    public void TakeDamage(int value)
    {
        health -= value;
    }

    private void OnEnable()
    {
        isAlive = true;
    }

    void Die()
    {
        Debug.Log("PlayerDie");
        isAlive = false;
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Restaurant>() != null)
        {
            onMission = true;
            newMission = other.GetComponent<Restaurant>();
        }

        if (other.tag == "FallDetector")
        {
            transform.position = respawnPoint;
            health -= 1;
        }
        else if (other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onMission = false;
    }
}
