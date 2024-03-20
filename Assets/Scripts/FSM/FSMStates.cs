using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FSMStates
{
    public string ID;
    public FSMAction[] allActions;
    public FSMTransittion[] allTransittions;




    public void UpdateState(Brain brain)
    {
        ExcuteAllAction();
        ExcuteTransittion(brain);
    }



    private void ExcuteAllAction()
    {
        foreach(FSMAction action in allActions) action.Action();
    }


    private void ExcuteTransittion(Brain brain)
    {
        foreach(FSMTransittion transition in allTransittions)
        {
            bool isTrueState = transition.decide.Decide();
            if (isTrueState)
            {
                brain.ChangeState(transition.trueState);
            }
            else
            {
                brain.ChangeState(transition.falseState);
            }
        }
    }
}
    

