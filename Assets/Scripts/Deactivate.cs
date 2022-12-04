using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    [SerializeField] GameObject deactivate;

    private void OnTriggerExit2D(Collider2D collision)
    {
        deactivate.gameObject.SetActive(false);
    }
}
