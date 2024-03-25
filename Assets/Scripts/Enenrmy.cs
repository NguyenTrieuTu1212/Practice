using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enenrmy : MonoBehaviour
{
    private bool isDetect;
    [SerializeField] private GameObject target;
    [SerializeField] private float timeBtwShoot;
    [SerializeField][Range(1f, 10f)] private float radius;
    [SerializeField] private LayerMask whatIsPlayer;
    

    private bool isShoot = false;
    private void Update()
    {
        if (CheckDetected() && !isShoot) StartCoroutine(WaitingShoot());
        
    }



    private void Shoot()
    {
        Bullet bullet = BulletManager.Instance.TakeBullet(transform.position);
        bullet.direction = target.transform.position - transform.position;
    }


    IEnumerator WaitingShoot()
    {
        isShoot = true;
        Shoot();
        yield return new WaitForSeconds(timeBtwShoot);
        isShoot=false;
    }

    private bool CheckDetected()
    {
        return Physics2D.OverlapCircle(transform.position,radius,whatIsPlayer);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
