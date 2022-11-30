using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float followSpeed = 2f;
    [SerializeField] float yOffset = 1f;
    [SerializeField] Transform target;

    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, 0 + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
