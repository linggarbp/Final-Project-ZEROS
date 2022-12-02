using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restaurant : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] int timeLine;
    [SerializeField] DataStorage dataStorage;

    private void Start()
    {
        if (sceneName == null || dataStorage == null)
        {
            Debug.Log("Attack all component in : " + this.name);
            return;
        }
    }

    private void Update()
    {
        if (timeLine != dataStorage.dataTimeline)
            gameObject.SetActive(false);
    }
    public void TakeMission()
    {
        if (dataStorage.dataTimeline == timeLine)
        {
            Debug.Log("Misi " + sceneName + " diambil");
            SceneManager.LoadScene(sceneName);
        }
        Debug.Log("Selesaikan Misi Sebelumnya");
        Debug.Log(dataStorage.dataTimeline);
    }
}
