using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    [SerializeField] AudioSource shoot;
    [SerializeField] GameObject player;
    float timebetween;

    [SerializeField] float startTimeBetween;

    private void Update()
    {
        if (BossMovement.isShooting)
        {
            if (timebetween <= 0)
            {
                if (Vector2.Distance(this.transform.position, player.transform.position) < 25)
                    shoot.Play();

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
