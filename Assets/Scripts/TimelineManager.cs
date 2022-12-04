using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] DataStorage dataStorage;

    private void update()
    {
        dataStorage.dataTimeline = PlayerPrefs.GetInt("TimeLine");
    }
}
