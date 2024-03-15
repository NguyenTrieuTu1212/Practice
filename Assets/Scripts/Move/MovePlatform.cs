using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField][Range(1f, 10f)] private float speed;
    private float moveX;
    private Vector2 moveDirection;
    [SerializeField][Range(1,10f)]private float jumpForce;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        ReadMovement();
        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.AddForce(transform.up * jumpForce);
        }
    }

    private void FixedUpdate()
    {
        Movement();
        
    }



    // ====================================== Way 1 ==================================

    private void ReadMovement()
    {
        moveX = Input.GetAxis("Horizontal");
        moveDirection = new Vector2(moveX, 0);
    }

    private void Movement()
    {
        rb2d.velocity = new Vector2(moveX * speed ,rb2d.velocity.y);
    }


    // ====================================== Way 2 ==================================
    private void MoveWay2()
    {
        rb2d.MovePosition(rb2d.position + moveDirection * speed * Time.deltaTime);   
    }

}
