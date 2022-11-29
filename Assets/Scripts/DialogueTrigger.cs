using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual & Trigger")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject trigger;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    private bool playerInteractable;

    private void Awake()
    {
        playerInRange = false;
        playerInteractable = true;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && playerInteractable && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            //if (InputManager.GetInstance().GetInteractPressed())
            if (Input.GetKeyDown(KeyCode.F))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                playerInteractable = false;
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerInRange = false;
    }
}
