using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChangeCyan : FSMAction
{
    public override void Action()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
    }
}
