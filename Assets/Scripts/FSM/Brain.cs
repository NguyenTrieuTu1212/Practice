using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    [SerializeField] private string initIDState;
    [SerializeField] private FSMState[] states;
    private FSMState currentState;


    private void Awake()
    {
        currentState = FindState(initIDState);
    }



    private void Update()
    {
        currentState?.UpdateState(this);
    }



    public void ChangeState(string IDNewState)
    {
        FSMState newState = FindState(IDNewState);
        if (newState == null) return;
        currentState = newState;
    }


    private FSMState FindState(string IDState)
    {
        foreach(FSMState state in states)
        {
            if(state.IDState == IDState) return state;
        }
        return null;
    }
}
