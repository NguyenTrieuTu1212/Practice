using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField][Range(1f,10f)] private float speedBullet;
    public Vector2 direction { get; set; }


    private void Update()
    {
        Shoot();
    }


    private void Shoot()
    {
        transform.Translate(direction * speedBullet * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider != null)
            BulletManager.Instance.ReturnBulletInQueue(gameObject.GetComponent<Bullet>());
    }
}
