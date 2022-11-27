using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStomp : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "WeakPoint")
        {
            Debug.Log("hit");
            Destroy(other.gameObject);
        }
    }
}
