using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Brain : MonoBehaviour
{
    [SerializeField] private string initState;
    public FSMStates[] states;

    private FSMStates currentState;



    private void Awake()
    {
        currentState = FindStates(initState);
        
    }


    private void Update()
    {
        currentState?.UpdateState(this);
    }


    public void ChangeState(string newStateID)
    {
        FSMStates newState = FindStates(newStateID);
        if (newState == null) return;
        currentState = newState;
    }

    private FSMStates FindStates(string nameState)
    {
        foreach (FSMStates state in states)
        {
            if(state.ID == nameState) return state;
        }
        return null;
    }
}
