using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shotting();
        }
    }


    private void Shotting()
    {
        Bullet bullet = BulletManager.Instance.TakeBullet(transform.position);
        bullet.direction = Vector2.right;
    }
}
