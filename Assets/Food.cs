using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public string foodName;

    public void TakeFood()
    {
        Debug.Log("taked" + foodName);
        Destroy(this.gameObject);
    }
}
