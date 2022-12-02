using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "ScriptableObject/DataStorage")]
public class DataStorage : ScriptableObject
{
    public int dataTimeline;
    public Vector2 saveLocation;

    // FOR DEVELOPMENT
    private void OnDisable()
    {
        dataTimeline = 0;
    }
}
