using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorDecide : FSMDecide
{
    [SerializeField] private float radial;
    [SerializeField] private LayerMask whatIsPlayerDetect;
    public override bool Decide()
    {
        bool isDetected = Physics2D.OverlapCircle(gameObject.transform.position, radial, whatIsPlayerDetect); ;
        return isDetected;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, radial);
    }
}
