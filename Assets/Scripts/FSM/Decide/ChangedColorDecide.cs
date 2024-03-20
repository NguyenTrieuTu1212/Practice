using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedColorDecide : FSMDecide
{

    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsLayer;
    public override bool Decide()
    {
        bool isDetected = Physics2D.OverlapCircle(transform.position, radius,whatIsLayer);
        return isDetected;  
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);  
    }
}
