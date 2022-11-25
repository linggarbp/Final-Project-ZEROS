using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] Finish finish;
    [SerializeField] string nextScene;
    SceneLoader sceneLoader;
    bool isRewarded;
    private void Start()
    {
        isRewarded = false;
        sceneLoader = GetComponent<SceneLoader>();
    }
    private void Update()
    {
        if (finish.IsFinish && isRewarded == false)
        {
            Reward();
            sceneLoader.Load(nextScene);
        }
    }

    void Reward()
    {
        if (inventory.Items.Count == 3)
            Debug.Log("3 Stars");
        else if (inventory.Items.Count == 2)
            Debug.Log("2 Stars");
        else
            Debug.Log("1 Stars");

        isRewarded = true;
    }
}
