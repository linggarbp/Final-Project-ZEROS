using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    Player player;
    PlayerStomp playerStomp;
    Inventory inventory;
    int lastM1Stomp;
    int lastM2Stomp;
    int lastM3Stomp;
    int lastHealth;
    int lastItemAdd;
    [SerializeField] AudioSource jumpSFX;
    [SerializeField] AudioSource runSFX;
    [SerializeField] AudioSource stompM1;
    [SerializeField] AudioSource stompM2;
    [SerializeField] AudioSource stompM3;
    [SerializeField] AudioSource playerTakeDamage;
    [SerializeField] AudioSource playerTakeItem;
    private void Start()
    {
        player = GetComponent<Player>();
        inventory = GetComponent<Inventory>();
        playerStomp = GetComponentInChildren<PlayerStomp>();
        lastHealth = player.health;
        lastItemAdd = inventory.itemAddSFX;

    }

    private void Update()
    {
        if (player.isGrounded && Input.GetKeyDown("w"))
            jumpSFX.Play();


        if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
            runSFX.Play();
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            runSFX.Stop();


        if (lastM1Stomp != playerStomp.m1Stomp)
        {
            stompM1.Play();
            lastM1Stomp = playerStomp.m1Stomp;
        }
        if (lastM2Stomp != playerStomp.m2Stomp)
        {
            stompM2.Play();
            lastM2Stomp = playerStomp.m2Stomp;
        }
        if (lastM3Stomp != playerStomp.m3Stomp)
        {
            stompM3.Play();
            lastM3Stomp = playerStomp.m3Stomp;
        }

        if (lastHealth != player.health)
        {
            playerTakeDamage.Play();
            lastHealth = player.health;
        }

        if (lastItemAdd != inventory.itemAddSFX)
        {
            playerTakeItem.Play();
            lastItemAdd = inventory.itemAddSFX;
        }
    }
}
