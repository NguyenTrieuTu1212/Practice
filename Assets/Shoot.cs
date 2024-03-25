using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField][Range(1,10f)] private float speed;
    [SerializeField] private Vector3 direction;

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
