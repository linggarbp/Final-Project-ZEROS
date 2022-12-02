using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStomp : MonoBehaviour
{
    [SerializeField] int stompDamage = 1;
    MonsterStats monsterStats;

    [SerializeField] Player player;
    [SerializeField] float monster2StompKBForce;

    private void Update()
    {
        if (stompDamage <= 0)
            Debug.Log(this.name + " : Stomp Damage <= 0");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Monster1")
        {
            Debug.Log(other.gameObject.name + " : Die");
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Monster2")
        {
            Debug.Log("hiii");
            monsterStats = other.gameObject.GetComponent<MonsterStats>();
            monsterStats.TakeDamage(stompDamage);
            KBForce(monster2StompKBForce, other.transform);
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
