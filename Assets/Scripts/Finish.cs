using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] DataStorage dataStorage;
    bool isRewarded;

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
        dataStorage.dataTimeLine++;
        isRewarded = true;
    }
}
