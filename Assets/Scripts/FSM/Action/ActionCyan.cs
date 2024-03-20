using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCyan : FSMAction
{
    public override void Action()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
    }

}
