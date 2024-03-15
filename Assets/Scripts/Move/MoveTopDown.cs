using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTopDown : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Vector2 readMoveDirection;
    [SerializeField][Range(1,10f)] private float speed;


   
    private Vector2 movement;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        ReadMove();
    }

    private void FixedUpdate()
    {
        MoveWay4();
    }


    // ======================== Move Top Down way 1 ===========================
    private void MoveWay1()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb2d.MovePosition(rb2d.position + movement * Time.deltaTime * speed);
    }


    // ======================== Move Top Down way 1 ===========================
    private void MoveWay2()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(moveX, moveY);
        rb2d.MovePosition(rb2d.position + moveDirection * Time.deltaTime * speed);
    }


    // ======================== Move Top Down way 3 ===========================


    private void MoveWay3()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(moveX, moveY);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }


    // ======================== Move Top Down way 3 ===========================

    private void ReadMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        readMoveDirection = new Vector2(moveX, moveY);  
    }

    private void MoveWay4()
    {
        rb2d.MovePosition(rb2d.position + readMoveDirection * Time.fixedDeltaTime * speed);  
    }

}
