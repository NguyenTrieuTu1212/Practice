using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAngel : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float angel;
    [SerializeField] private float timeBtwShoot;
    [SerializeField] private float timeOnce;
    private bool isShoot = false;
    private void Update()
    {
        if(!isShoot)StartCoroutine(WaitingShoot());
    }

    IEnumerator WaitingShoot()
    {
        isShoot = true;
        angel += 60;
        GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.Euler(0, 0, angel));
        yield return new WaitForSeconds(timeBtwShoot);
        isShoot = false;
    }
}
