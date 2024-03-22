using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField][Range(1f, 10f)] private float speedBullet;


    public Vector3 direction;



    private void Update()
    {
        Shoot();
    }


    private void Shoot()
    {
        transform.Translate(direction * speedBullet * Time.deltaTime);
    }
}
