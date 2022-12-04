using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Shelter : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] DataStorage dataStorage;
    [SerializeField] string nextScene;
    [SerializeField] TMP_Text finishText;
    [SerializeField] GameObject completePanel;
    [SerializeField] GameObject failedPanel;
    bool onShelter;
    private void Start()
    {
        onShelter = false;
    }

    private void Update()
    {
        if (inventory == null || dataStorage == null || nextScene == null)
            Debug.Log("Attach all Component to : " + this.name);

        if (Input.GetKey("e") && onShelter)
        {
            ShelterReward();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            onShelter = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onShelter = false;
    }

    void ShelterReward()
    {
        if (inventory.Items.Count > 0)
        {
            finishText.text = "Selamat Atas Kontribusi Kamu, " + inventory.Items.Count + " Makanan Berhasil Diantarkan :)";
            completePanel.SetActive(true);
            dataStorage.dataTimeline++;
            PlayerPrefs.SetInt("Timeline", dataStorage.dataTimeline);
            Invoke("Complete", 10);
        }
        else
        {
            finishText.text = "Makanan belum terkumpul semuanya :( ,  kembali lagi jika sudah mendapatkannya :D ";
            failedPanel.SetActive(true);
            Invoke("Failed", 5);
        }

        foreach (var item in inventory.Items)
        {
            inventory.Items.Remove(item);
        }
        inventory.Items.Clear();

    }
    void Complete()
    {
        SceneManager.LoadScene(nextScene);
    }
    void Failed()
    {
        failedPanel.SetActive(false);
    }
}
