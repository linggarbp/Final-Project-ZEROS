using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shelter : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] DataStorage dataStorage;
    [SerializeField] string nextPart;
    bool isRewarded;

    private void Update()
    {
        if (inventory == null || dataStorage == null || nextPart == null)
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

        foreach (var item in inventory.Items)
        {
            inventory.Items.Remove(item);
        }
        inventory.Items.Clear();

        // TIME LINE CONTINUE
        dataStorage.dataTimeline++;
        PlayerPrefs.SetInt("Timeline", dataStorage.dataTimeline);
        isRewarded = true;
        SceneManager.LoadScene(nextPart);
    }
}
