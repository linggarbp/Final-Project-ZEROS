using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerSign : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            popUp.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        popUp.SetActive(false);
    }
}
