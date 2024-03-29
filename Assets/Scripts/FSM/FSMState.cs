using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FSMState 
{
    public string IDState;
    public FSMAction[] listAction;
    public FSMTransition[] listTransition;



    public void UpdateState(Brain brain)
    {
        ExcuteAllAction();
        ExcuteAllTrasition(brain);
    }
    

    private void ExcuteAllAction()
    {
        foreach(FSMAction action in listAction) action.Action();
    }


    private void ExcuteAllTrasition(Brain brain)
    {
        foreach (FSMTransition transition in listTransition)
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
