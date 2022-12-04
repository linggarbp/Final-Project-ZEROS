using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] DataStorage dataStorage;
    [SerializeField] Button continueButton;
    private void Start()
    {
        dataStorage.dataTimeline = PlayerPrefs.GetInt("Timeline");
        if (PlayerPrefs.GetInt("Timeline") == 0)
            continueButton.interactable = false;
    }

    [ContextMenu("ResetTimeLine")]
    public void ClickNewGame()
    {
        PlayerPrefs.SetInt("Timeline", 0);
        dataStorage.dataTimeline = 0;
        SceneManager.LoadScene("StoryMode1");
    }

    public void ClickContinue()
    {
        SceneManager.LoadScene("OpenWorld");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
