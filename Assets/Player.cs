using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    bool onMission;
    Mission newMission;
    private void Update()
    {
        if (Input.GetKey("e") && onMission)
        {
            newMission.TakeMission();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Mission>() != null)
        {
            onMission = true;
            newMission = other.GetComponent<Mission>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onMission = false;
    }
}
