using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "ScriptableObject/DataStorage")]
public class DataStorage : ScriptableObject
{
    public int dataTimeLine;
    private void OnDisable()
    {
        dataTimeLine = 0;
    }
}
