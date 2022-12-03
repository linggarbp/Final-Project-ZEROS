using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] int damage = 2;
    [SerializeField] int playerKBForce = 7;
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (player == null || playerKBForce <= 0)
        {
            Debug.Log("Attach all required reference to component : " + this.name);
            return;
        }

        if (other.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("Seruduk");
            player = other.gameObject.GetComponent<Player>();
            player.KBForce = playerKBForce;

            player.KBCounter = player.totalTime;
            if (other.transform.position.x <= transform.position.x)
                player.KnockFromRight = true;

            if (other.transform.position.x >= transform.position.x)
                player.KnockFromRight = false;

            player.TakeDamage(damage);
        }
    }
}
