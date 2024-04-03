using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField][Range(1f, 10f)] private float speedPlayer;
    private Rigidbody2D rb2d;
    private Vector2 moveDirection;


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
        Moving();
    }



    private void ReadMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveX, moveY);
    }


    private void Moving()
    {
        rb2d.MovePosition(rb2d.position + moveDirection * speedPlayer * Time.deltaTime);
    }
}
