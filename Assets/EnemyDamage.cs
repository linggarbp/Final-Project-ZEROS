using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Player player;
    [SerializeField] PlayerMovement playerMovement;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
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
            player.TakeDamage(damage);
        }
    }
}
