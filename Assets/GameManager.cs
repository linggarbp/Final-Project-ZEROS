using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int timeLine;

    [ContextMenu("ResetTimeLine")]
    public void ResetTimeline()
    {
        PlayerPrefs.SetFloat("Timeline", 0);
        Debug.Log("Timeline Reset to 0");
    }

    private void Awake()
    {
        timeLine = PlayerPrefs.GetInt("TimeLine");
    }



}
