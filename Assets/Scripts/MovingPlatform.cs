using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] bool twoWay;
    [SerializeField] float moveSpeed;
    [SerializeField] int patrolDestination;

    private void Update()
    {
        if (!twoWay)
        {
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    patrolDestination = 2;
                }
            }
            if (patrolDestination == 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[2].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[2].position) < .2f)
                {
                    patrolDestination = 0;
                }
            }
        }
        if (twoWay)
        {
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    patrolDestination = 0;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            other.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }
}
