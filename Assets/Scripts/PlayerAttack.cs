using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    GameObject attackArea = default;

    bool attacking = false;

    float timeToAttack = 0.25f;
    float timer = 0.25f;

    private void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Attack();
        //}

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
