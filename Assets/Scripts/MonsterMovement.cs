using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [Header("MONSTER MOVEMENT")]
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] int patrolDestination = 2;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] bool isChasing;
    [SerializeField] float cheseDistance = 4;
    public static bool isDirChange;

    [Header("CHASING TARGET")]
    [SerializeField] Transform player;

    private void Update()
    {
        // Check if patrol point is null
        if (patrolPoints[0] == null || patrolPoints[1] == null || player == null)
        {
            Debug.Log("Attach all required reference to component : " + this.name);
            return;
        }

        // CHASING TARGET SYSTEM
        if (isChasing)
        {
            if (player == null || !Player.isAlive)
            {
                isChasing = false;
                return;
            }

            if (transform.position.x > player.position.x)
            {
                MonsterBullet.isDirToRight = false;
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < player.position.x)
            {
                MonsterBullet.isDirToRight = true;
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (player != null)
                if (Vector2.Distance(transform.position, player.position) < cheseDistance)
                    isChasing = true;

            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    isDirChange = true;
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 1;
                    MonsterBullet.isDirToRight = false;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    isDirChange = true;
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 0;
                    MonsterBullet.isDirToRight = true;
                }
            }
        }

    }

}

