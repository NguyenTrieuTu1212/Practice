using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWaypoint : MonoBehaviour
{
    [SerializeField][Range(1,10f)] private float speedMovePlatform;
    [SerializeField] private List<Transform> listPoint = new List<Transform>();
    private int indexPoint;
    private Vector3 targetPos;
    private int countPoint;
    private int direction = 0;
    private void Awake()
    {
        indexPoint = 0;
        countPoint = listPoint.Count -1;
        
    }

    private void Start()
    {
        targetPos = listPoint[indexPoint].position;
    }


    private void Update()
    {
        MoveWayPoint();
    }



    private void MoveWayPoint()
    {
        Vector3 movement = (targetPos - transform.position).normalized;
        transform.Translate(movement * speedMovePlatform * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos) <= 0.05f) MoveNextPoint(); 
    }


    private void MoveNextPoint()
    {
        if (indexPoint == 0) direction = 1;
        else if(indexPoint == countPoint) direction = -1;
        indexPoint += direction;
        targetPos = listPoint[indexPoint].position;
    }
}
