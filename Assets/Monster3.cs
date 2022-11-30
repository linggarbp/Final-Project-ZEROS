using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonoBehaviour
{
    [SerializeField] int maxHealth = 15;
    [SerializeField] int health;
    [SerializeField] PlayerMovement playerMovement;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            playerMovement.KBCounter = playerMovement.totalTime;
            if (other.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }
            if (other.transform.position.x >= transform.position.x)
            {
                playerMovement.KnockFromRight = false;
            }
            health -= 1;
            if (health <= 0)
                Destroy(gameObject);
        }
    }

}
