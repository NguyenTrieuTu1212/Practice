using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FSMTransition 
{
    public FSMDecide decide;
    public string trueState;
    public string falseState;
}
