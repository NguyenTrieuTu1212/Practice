using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField][Range(1f, 10f)] private float speedPlayer;
    private Vector2 direction;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void ReadMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        direction = new Vector2(moveX, moveY);
    }


    private void Move()
    {
        rb2d.MovePosition(rb2d.position + direction * speedPlayer * Time.deltaTime);
    }

}
