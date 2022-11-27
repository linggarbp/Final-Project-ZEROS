using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "ScriptableObject/DataStorage")]
public class DataStorage : ScriptableObject
{
    public int itemCollect;
    private void OnDisable()
    {
        itemCollect = 0;
    }
}
