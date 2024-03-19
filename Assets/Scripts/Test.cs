using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int myIndex;
    [SerializeField]
    private int myIndexPrivate = 0;


    [ContextMenu("Add Index public")]
    public void AddIndex()
    {
        myIndexPrivate++;
        Debug.Log(myIndexPrivate);
    }
}
