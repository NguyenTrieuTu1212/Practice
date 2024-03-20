using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRed : FSMAction
{
    public override void Action()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
