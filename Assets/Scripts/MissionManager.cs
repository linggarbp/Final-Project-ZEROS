using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;


    SceneLoader sceneLoader;
    private void Start()
    {

        sceneLoader = GetComponent<SceneLoader>();
    }

}
