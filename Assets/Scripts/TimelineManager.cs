using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] DataStorage dataStorage;
    private void Start()
    {
        dataStorage.dataTimeline = PlayerPrefs.GetInt("Timerline");
    }

    [ContextMenu("ResetTimeLine")]
    public void ClickNewGame()
    {
        PlayerPrefs.SetInt("Timeline", 0);
        dataStorage.dataTimeline = 0;
    }

    public void ClickContinue()
    {
        PlayerPrefs.SetInt("Timeline", 0);
        Debug.Log("Timeline Reset to 0");
    }

    private void update()
    {
        dataStorage.dataTimeline = PlayerPrefs.GetInt("TimeLine");
    }
}
