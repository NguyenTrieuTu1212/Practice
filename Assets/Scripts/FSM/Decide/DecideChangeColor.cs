using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideChangeColor : FSMDecide
{
    [SerializeField][Range(1,10f)] private float radius;
    [SerializeField] private LayerMask whatIsDetected;
    public override bool Decide()
    {
        bool isDectect = Physics2D.OverlapCircle(transform.position, radius, whatIsDetected);
        return isDectect;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
