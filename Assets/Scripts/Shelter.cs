using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Shelter : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] DataStorage dataStorage;
    [SerializeField] GameObject popUp;
    [SerializeField] string nextScene;
    [SerializeField] TMP_Text finishText;
    [SerializeField] GameObject shelterPanel;
    [SerializeField] AudioSource shelterSFX;
    [SerializeField] AudioSource shelterPressedSFX;
    bool onShelter;
    private void Start()
    {
        onShelter = false;
        popUp.SetActive(false);
        shelterPanel.SetActive(false);
    }

    private void Update()
    {
        if (inventory == null || dataStorage == null || nextScene == null || shelterPanel == null)
            Debug.Log("Attach all Component to : " + this.name);

        if (Input.GetKey("e") && onShelter)
        {
            ShelterReward();
            shelterPressedSFX.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            popUp.SetActive(true);
            onShelter = true;
            shelterSFX.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        popUp.SetActive(false);
        onShelter = false;
    }

    void ShelterReward()
    {
        if (inventory.Items.Count == 7)
        {
            if (SceneManager.GetActiveScene().name == "StoryMode5")
            {
                finishText.text = "Thanks for Playing :) ";
            }

            else
            {
                finishText.text = "Selamat Kamu Sudah Berhasil  Mengantarkan Semua Makanan :) ";
            }

            dataStorage.dataTimeline++;
            PlayerPrefs.SetInt("Timeline", dataStorage.dataTimeline);
            shelterPanel.SetActive(true);
            Invoke("Complete", 10);


        }
        else if (inventory.Items.Count < 7)
        {
            finishText.text = "Makanan Terkumpul " + inventory.Items.Count + "/7   Kembali Lagi Jika Sudah Terkumpul Semua :(";
            shelterPanel.SetActive(true);
            Invoke("Failed", 5);
        }



    }
    void Complete()
    {
        SceneManager.LoadScene(nextScene);
        //foreach (var item in inventory.Items)
        //{
        //    inventory.Items.Remove(item);
        //}
        //inventory.Items.Clear();
    }
    void Failed()
    {
        shelterPanel.SetActive(false);
    }
}
