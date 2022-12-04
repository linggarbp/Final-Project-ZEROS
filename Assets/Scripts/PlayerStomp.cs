using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStomp : MonoBehaviour
{
    [SerializeField] int stompDamage = 1;
    MonsterStats monsterStats;
    Monster3 monster3;

    [SerializeField] Player player;
    [SerializeField] float m2StompKBForce = 7;
    [SerializeField] float m3StompKBForce = 7;

    [HideInInspector] public int m1Stomp;
    [HideInInspector] public int m2Stomp;
    [HideInInspector] public int m3Stomp;

    private void Update()
    {
        if (stompDamage <= 0)
            Debug.Log(this.name + " : Stomp Damage <= 0");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Monster1")
        {
            m1Stomp++;
            Debug.Log(other.gameObject.name + " : Die");
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Monster2")
        {
            m2Stomp++;
            Debug.Log("Stomp m2");
            monsterStats = other.gameObject.GetComponent<MonsterStats>();
            monsterStats.TakeDamage(stompDamage);
            KBForce(m2StompKBForce, other.transform);
        }
        if (other.gameObject.tag == "Monster3")
        {
            m3Stomp++;
            Debug.Log("Stomp m2");
            monster3 = other.gameObject.GetComponent<Monster3>();
            monster3.TakeDamage(stompDamage);
            KBForce(m3StompKBForce, other.transform);
        }
    }
    void KBForce(float newForce, Transform other)
    {
        player = GetComponentInParent<Player>();
        player.KBForce = newForce;

        player.KBCounter = player.totalTime;
        if (transform.position.x <= other.transform.position.x)
            player.KnockFromRight = true;

        if (transform.position.x >= other.transform.position.x)
            player.KnockFromRight = false;
    }
}
