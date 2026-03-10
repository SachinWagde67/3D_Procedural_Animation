using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<StateEnum> : MonoBehaviour where StateEnum : Enum {

    protected Dictionary<StateEnum, BaseState<StateEnum>> statesMap = new Dictionary<StateEnum, BaseState<StateEnum>>();
    public BaseState<StateEnum> CurrentState { get; protected set; }
    protected bool isChangingState = false;


    private void Start() {
        CurrentState.EnterState();
    }

    private void Update() {

        if(!isChangingState) {
            CurrentState.UpdateState();
        }

        //StateEnum nextState = CurrentState.GetNextState();

        ////If Next State is same as current State
        //if(!isChangingState && nextState.Equals(CurrentState.State)) {
        //    CurrentState.UpdateState();

        //} else {
        //    ChangeState(nextState);
        //}
    }

    protected void ChangeState(StateEnum nextState) {

        Debug.Log($"CurrentState - {nextState}");

        if(CurrentState.State.Equals(nextState)) {
            return;
        }

        isChangingState = true;
        CurrentState.ExitState();
        CurrentState = statesMap[nextState];
        CurrentState.EnterState();
        isChangingState = false;
    }

    private void OnTriggerEnter(Collider other) {

        CurrentState.OnTriggerEnter(other);
    }

    private void OnTriggerStay(Collider other) {

        CurrentState.OnTriggerStay(other);
    }

    private void OnTriggerExit(Collider other) {
        CurrentState.OnTriggerExit(other);
    }
}
