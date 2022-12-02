using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restaurant : MonoBehaviour
{
    [SerializeField] string partName;
    [SerializeField] int timeLine;
    [SerializeField] DataStorage dataStorage;

    private void Start()
    {
        if (partName == null || dataStorage == null)
        {
            Debug.Log("Attack all component in : " + this.name);
            return;
        }
    }

    private void Update()
    {
        if (timeLine != dataStorage.dataTimeline)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
    public void TakeMission()
    {
        if (dataStorage.dataTimeline == timeLine)
        {
            Debug.Log("Misi " + partName + " diambil");
            SceneManager.LoadScene(partName);
        }
        Debug.Log("Selesaikan Misi Sebelumnya");
        Debug.Log(dataStorage.dataTimeline);
    }
}
