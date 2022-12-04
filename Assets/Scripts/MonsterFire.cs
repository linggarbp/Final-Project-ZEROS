using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFire : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    float timebetween;

    [SerializeField] float startTimeBetween = 1;

    private void Start()
    {
        timebetween = startTimeBetween;
    }

    private void Update()
    {
        if (firePoint == null || bullet == null || startTimeBetween <= 0)
        {
            Debug.Log("Attach all required reference to component : " + this.name);
            return;
        }

        StartCoroutine(Fire());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Fire()
    {
        if (MonsterMovement.isDirChange)
            yield return new WaitForSeconds(0.4f);

        if (timebetween <= 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            timebetween = startTimeBetween;
        }
        else
            timebetween -= Time.deltaTime;

    }
}
