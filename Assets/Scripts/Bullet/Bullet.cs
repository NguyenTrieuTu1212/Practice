using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] private float speedBullet;
    public Vector3 direction { get; set;}



    private void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        transform.Translate(direction * speedBullet * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BulletManager.Instance.ReturnBullet(gameObject.GetComponent<Bullet>());
        }
    }
}
