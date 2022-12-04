using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonoBehaviour
{
    [Header("STATS")]
    [SerializeField] int maxHealth = 15;
    [SerializeField] int health;

    [SerializeField] Player player;

    private void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        if (maxHealth <= 0 || player == null)
            Debug.Log("Attach All Component value right in :" + this.name);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        // if (other.gameObject.tag == "Player")
        // {
        //     player.KBCounter = player.totalTime;
        //     if (other.transform.position.x <= transform.position.x)
        //     {
        //         player.KnockFromRight = true;
        //     }
        //     if (other.transform.position.x >= transform.position.x)
        //     {
        //         player.KnockFromRight = false;
        //     }
        //     health -= 1;

        // }
    }

}
