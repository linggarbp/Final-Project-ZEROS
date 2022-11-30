using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    float timebetween;

    [SerializeField] float startTimeBetween;

    private void Update()
    {
        if (BossMovement.isShooting)
        {
            if (timebetween <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                timebetween = startTimeBetween;
            }
            else
            {
                timebetween -= Time.deltaTime;
            }
        }
    }
}
