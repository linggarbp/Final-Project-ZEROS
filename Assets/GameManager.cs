using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int timeLine;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
    private void Start()
    {
        timeLine = PlayerPrefs.GetInt("TimeLine");
    }



}
