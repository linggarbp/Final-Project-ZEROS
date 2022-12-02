using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restaurant : MonoBehaviour
{
    [SerializeField] string missionName;
    [SerializeField] int timeLine;
    [SerializeField] DataStorage dataStorage;

    private void Update()
    {
        if (timeLine != dataStorage.dataTimeLine)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
    public void TakeMission()
    {
        Debug.Log(missionName);
        if (dataStorage.dataTimeLine == timeLine)
        {
            Debug.Log("Misi diambil");
            SceneManager.LoadScene(missionName);
        }
        Debug.Log("Selesaikan Misi Sebelumnya");
        Debug.Log(dataStorage.dataTimeLine);
    }
}
