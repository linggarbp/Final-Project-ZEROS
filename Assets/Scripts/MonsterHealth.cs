using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    int health;
    private void Start()
    {
        health = maxHealth;
    }
    public void Damage(int amount)
    {
        health -= amount;
    }
}
