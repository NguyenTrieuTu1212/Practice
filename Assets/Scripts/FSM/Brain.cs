using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    [SerializeField] private string initState;
    [SerializeField] private FSMStates[] states;

    private FSMStates currentState;

    private void Awake()
    {
        currentState = FindStates(initState);
    }



    private void Update()
    {
        currentState?.UpdateState(this);
    }


    private FSMStates FindStates(string ID)
    {
        foreach(FSMStates state in states) if (state.ID == ID) return state;
        return null;
    }


    public void ChangeState(string newStateChanged)
    {
        FSMStates newState = FindStates(newStateChanged);
        if (newState == null) return;
        currentState = newState;
    }

}
