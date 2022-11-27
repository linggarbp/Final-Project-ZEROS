using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission : MonoBehaviour
{
    [SerializeField] string missionName;
    [SerializeField] int itemRequired;
    [SerializeField] DataStorage dataStorage;

    public void TakeMission()
    {

        Debug.Log(missionName);
        if (dataStorage.itemCollect >= itemRequired)
        {
            Debug.Log("Misi diambil");
            SceneManager.LoadScene(missionName);
        }
        Debug.Log("Selesaikan Misi Sebelumnya");
        Debug.Log(dataStorage.itemCollect);
    }
}
