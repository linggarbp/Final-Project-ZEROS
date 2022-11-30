using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    [SerializeField] GameObject rend;

    private void Start()
    {
        rend.SetActive(false);
    }
}
