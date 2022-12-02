using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] DataStorage dataStorage;
    bool isRewarded;

    private void Update()
    {
        if (inventory == null || dataStorage == null)
            Debug.Log("Attach all Component to : " + this.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isRewarded)
                return;

            ShelterReward();
            // sceneLoader.Load("Open World");

        }
    }
    void ShelterReward()
    {
        if (inventory.Items.Count == 3)
            Debug.Log("3 Stars");
        else if (inventory.Items.Count == 2)
            Debug.Log("2 Stars");
        else
            Debug.Log("1 Stars");

        // TIME LINE CONTINUE
        dataStorage.dataTimeline++;
        PlayerPrefs.SetInt("Timeline", dataStorage.dataTimeline);
        isRewarded = true;
    }
}
