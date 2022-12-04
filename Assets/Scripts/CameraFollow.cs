using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float followSpeed = 2f;
    [SerializeField] float yOffset = 1f;

    private void Update()
    {
        Vector3 newPos = new Vector3(target.transform.position.x, 0 + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);

    }
}
