using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float spinSpeed;
    [SerializeField] int bulletDamage = 1;
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
        if (isDirToRight)
        {
            transform.Rotate(0, 0, -1 * spinSpeed);
        }
        else if (!isDirToRight)
        {
            transform.Rotate(0, 0, 1 * spinSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
            Player.health -= 1;

        if (other.gameObject.tag != "WeakPoint")
            Destroy(gameObject);
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
