using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission : MonoBehaviour
{
    [SerializeField] int itemRequired;
    [SerializeField] DataStorage dataStorage;

    public void TakeMission()
    {
        if (dataStorage.itemCollect > itemRequired)
        {
            Debug.Log("Misi diambil");
        }
        else
            Debug.Log("Selesaikan Misi Sebelumnya");
    }
}
