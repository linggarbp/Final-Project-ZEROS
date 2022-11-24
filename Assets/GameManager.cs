using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] Finish finish;
    private void Update()
    {
        Debug.Log(inventory.Items.Count);
        // // jika player sampai tempat tujuan
        // if (finish.IsFinish)
        // {

        //     if (inventory.Items.Count > 0)
        //         Debug.Log
        // }
    }
}
