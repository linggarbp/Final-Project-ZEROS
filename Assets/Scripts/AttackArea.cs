using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] int damage = 3;

    // flip attack area

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MonsterHealth>() != null)
        {
            MonsterHealth health = other.GetComponent<MonsterHealth>();
            health.Damage(damage);
        }
    }
}
