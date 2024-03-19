using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedAction : FSMAction
{

    public override void Action()
    { 
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
