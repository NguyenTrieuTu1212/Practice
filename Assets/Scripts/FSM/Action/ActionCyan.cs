using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCyan : FSMAction
{

    [SerializeField] private GameObject target;
    [SerializeField][Range(1f,10f)] private float timeBtwShoot;

    private bool isShooting = false;
    
    public override void Action()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        if(!isShooting) StartCoroutine(WaitingNextShoot());
    }




    IEnumerator WaitingNextShoot()
    {
        isShooting = true;
        Shoot();
        yield return new WaitForSeconds(timeBtwShoot);
        isShooting=false;
    }

    private void Shoot()
    {
        Vector3 dir = target.transform.position - transform.position;
        Bullet bullet = BulletManager.Instance.TakeBullet(transform.position);
        bullet.direction = dir;
    }
    

    
}
