using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField][Range(1, 10)] private float speedPlayer;
    private Rigidbody2D rb2d;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (rb2d == null) return;
    }




    private void Update()
    {
        ReadMoving();
    }


    private void FixedUpdate()
    {
        Moving();
    }


    private void ReadMoving()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveX, moveY);
    }

    private void Moving()
    {
        rb2d.MovePosition(rb2d.position + moveDirection * speedPlayer * Time.fixedDeltaTime);
    }


    
}
