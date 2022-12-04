using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restaurant : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] int timeLine;
    [SerializeField] DataStorage dataStorage;
    [SerializeField] GameObject PopUp;
    [SerializeField] AudioSource restaurantSFX;
    [SerializeField] AudioSource restaurantPressedSFX;

    private void Start()
    {
        PopUp.SetActive(false);
        if (sceneName == null || dataStorage == null || restaurantPressedSFX == null || restaurantSFX == null)
        {
            Debug.Log("Attack all component in : " + this.name);
            return;
        }
    }

    private void Update()
    {
        if (timeLine != dataStorage.dataTimeline)
            gameObject.SetActive(false);
    }
    public void TakeMission()
    {
        if (dataStorage.dataTimeline == timeLine)
        {
            Debug.Log("Misi " + sceneName + " diambil");
            SceneManager.LoadScene(sceneName);
        }
        Debug.Log("Selesaikan Misi Sebelumnya");
        Debug.Log(dataStorage.dataTimeline);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            restaurantSFX.Play();
            PopUp.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        PopUp.SetActive(false);
    }
}
