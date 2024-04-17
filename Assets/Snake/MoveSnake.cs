using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnake : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MovingSnake();
        }
    }


    private void MovingSnake()
    {
        transform.position += new Vector3Int(0, 1, 0);
    }



}
