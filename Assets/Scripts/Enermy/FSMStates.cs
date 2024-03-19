using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FSMStates 
{
    public string ID;
    public FSMAction[] allAction;
    public FSMTransittion[] allTrasittion;





    public void UpdateState(Brain brain)
    {
        ExcuteAction();
        ExcuteTrasittion(brain);
    }

    public void ExcuteAction()
    {
        foreach (FSMAction action in allAction) action.Action();
    }



    public void ExcuteTrasittion(Brain brain)
    {
        foreach(FSMTransittion transittion in allTrasittion)
        {
            bool istrueState = transittion.decide.Decide();
            if (istrueState)
            {
                brain.ChangeState(transittion.trueState);
            }
            else {
                brain.ChangeState(transittion.falseState);
            }
        }
    }
}
