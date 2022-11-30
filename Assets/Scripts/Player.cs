using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    bool onMission;
    Mission newMission;

    Vector3 respawnPoint;

    private void Start()
    {
        respawnPoint = transform.position;

        health = maxHealth;
    }
    private void Update()
    {
        if (Input.GetKey("e") && onMission)
        {
            newMission.TakeMission();
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Attack()
    {

    }

    public void TakeDamage(int value)
    {
        health -= value;
    }


    void Die()
    {
        Debug.Log("PlayerDie");
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Mission>() != null)
        {
            onMission = true;
            newMission = other.GetComponent<Mission>();
        }

        if (other.tag == "FallDetector")
        {
            transform.position = respawnPoint;
            health -= 1;
        }
        else if (other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onMission = false;
    }
}
