using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    Player player;
    PlayerStomp playerStomp;
    int lastM1Stomp;
    int lastM2Stomp;
    int lastM3Stomp;
    [SerializeField] AudioSource jumpSFX;
    [SerializeField] AudioSource runSFX;
    [SerializeField] AudioSource stompM1;
    [SerializeField] AudioSource stompM2;
    [SerializeField] AudioSource stompM3;
    private void Awake()
    {
        player = GetComponent<Player>();
        playerStomp = GetComponentInChildren<PlayerStomp>();
    }

    private void Update()
    {
        if (player.isGrounded && Input.GetKeyDown("w"))
            jumpSFX.Play();


        if ((Input.GetKeyDown("a") || Input.GetKeyDown("d")))
            runSFX.Play();
        else if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            runSFX.Stop();


        if (lastM1Stomp != playerStomp.m1Stomp)
        {
            stompM1.Play();
            lastM1Stomp = playerStomp.m1Stomp;
        }
        if (lastM2Stomp != playerStomp.m2Stomp)
        {
            stompM1.Play();
            lastM2Stomp = playerStomp.m2Stomp;
        }
        if (lastM3Stomp != playerStomp.m3Stomp)
        {
            stompM1.Play();
            lastM3Stomp = playerStomp.m3Stomp;
        }
    }
}
