using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCheckpoint : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    bool isPlayer;
    private void Awake()
    {
        isPlayer = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!isPlayer)
            {
                sfx.Play();
                isPlayer = true;
            }
        }
    }
}
