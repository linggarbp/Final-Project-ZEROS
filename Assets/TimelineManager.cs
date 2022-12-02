using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] DataStorage dataStorage;

    [ContextMenu("ResetTimeLine")]
    public void ResetTimeline()
    {
        PlayerPrefs.SetFloat("Timeline", 0);
        Debug.Log("Timeline Reset to 0");
    }

    private void update()
    {
        dataStorage.dataTimeline = PlayerPrefs.GetInt("TimeLine");
    }
}
