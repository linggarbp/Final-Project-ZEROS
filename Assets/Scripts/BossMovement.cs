using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float moveSpeed;
    [SerializeField] int patrolDestination;

    [Header("ANIMATION")]
    [SerializeField] Animator animator;
    bool isRunning;
    public static bool isShooting;

    private void Update()
    {
        // Check if patrol point is null
        if (patrolPoints[0] == null || patrolPoints[1] == null || animator == null)
        {
            Debug.Log("Attach all required reference to component : " + this.name);
            return;
        }
        // animator
        animator.SetBool("isAttack", isRunning);

        if (patrolDestination == 0)
        {
            isRunning = true;
            isShooting = false;
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                MonsterBullet.isDirToRight = false;
                patrolDestination = 2;
            }
        }

        if (patrolDestination == 1)
        {
            isRunning = true;
            isShooting = false;
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                MonsterBullet.isDirToRight = true;
                patrolDestination = 3;
            }
        }

        if (patrolDestination == 2)
        {
            isRunning = false;
            StartCoroutine(Timer1());

        }
        if (patrolDestination == 3)
        {
            isRunning = false;
            StartCoroutine(Timer2());

        }
    }
    IEnumerator Timer1()
    {
        isShooting = true;
        yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(3);
        patrolDestination = 1;
    }
    IEnumerator Timer2()
    {
        yield return new WaitForSeconds(3);
        isShooting = true;
        yield return new WaitForSeconds(3);
        patrolDestination = 0;

    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    // [SerializeField] PlayerMovement playerMovement;
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.GetComponent<Player>() != null)
    //     {
    //         playerMovement.KBCounter = playerMovement.totalTime;
    //         if (other.transform.position.x <= transform.position.x)
    //         {
    //             playerMovement.KnockFromRight = true;
    //         }
    //         if (other.transform.position.x >= transform.position.x)
    //         {
    //             playerMovement.KnockFromRight = false;
    //         }
    //     }
    // }

}



