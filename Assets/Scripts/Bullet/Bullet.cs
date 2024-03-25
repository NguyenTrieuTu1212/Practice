using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction { get; set; }

    [SerializeField][Range(1f, 10f)] private float speedBullet;


    private void Update()
    {
        Shoot();
    }


    private void Shoot()
    {
        transform.Translate(direction * speedBullet * Time.deltaTime);
    }
}
