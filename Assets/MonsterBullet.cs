using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float spinSpeed = 5;
    [SerializeField] int bulletDamage = 1;

    Player player;
    float lifeTime = 5;
    public static bool isDirToRight;
    Rigidbody2D rb;
    private void Start()
    {
        if (MonsterMovement.isDirChange)
            StartCoroutine(WaitFire());

        rb = GetComponent<Rigidbody2D>();
        if (isDirToRight)
            rb.velocity = transform.right * speed;
        else
            rb.velocity = transform.right * -speed;
    }

    private void Update()
    {
        if (speed <= 0 || bulletDamage <= 0)
        {
            Debug.Log(this.name + " value can't <= 0");
            return;
        }

        if (isDirToRight)
            transform.Rotate(0, 0, -1 * spinSpeed);
        else if (!isDirToRight)
            transform.Rotate(0, 0, 1 * spinSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            player = other.gameObject.GetComponent<Player>();
            player.TakeDamage(bulletDamage);
        }

        if (other.gameObject.tag != "Monster2")
            gameObject.SetActive(false);
    }
    IEnumerator WaitFire()
    {
        yield return new WaitForSeconds(0.2f);
        MonsterMovement.isDirChange = false;
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
