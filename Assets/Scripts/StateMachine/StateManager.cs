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

        ////If Next State is same as current State
        //if(!isChangingState && currentState.GetNextState().Equals(currentState.State)) {
        //    currentState.UpdateState();

        //} else {
        //    ChangeState(currentState.GetNextState());
        //}
    }

    public void ChangeState(StateEnum newState) {

        if(CurrentState.State.Equals(newState)) {
            return;
        }

        isChangingState = true;
        CurrentState.ExitState();
        CurrentState = statesMap[newState];
        CurrentState.EnterState();
        isChangingState = false;

        //isChangingState = true;
        //currentState.ExitState();
        //currentState = statesMap[newState];
        //currentState.EnterState();
        //isChangingState = false;
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
