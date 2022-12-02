using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    [Header("MONSTER STATS")]
    public int maxHealth = 10;
    public int health;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (maxHealth <= 0)
            Debug.Log(this.name + " : Max Health value can't <= 0");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log(this.name + " Die");
            gameObject.SetActive(false);
        }
    }
}
