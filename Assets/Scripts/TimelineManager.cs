using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] DataStorage dataStorage;
    private void Start()
    {
        dataStorage.dataTimeline = PlayerPrefs.GetInt("TimeLine");
    }

    private void update()
    {

    }
}
