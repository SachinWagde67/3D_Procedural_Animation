using System;
using UnityEngine;

public abstract class BaseState<StateEnum> where StateEnum : Enum {

    public BaseState(StateEnum state) {
        State = state;
    }

    public StateEnum State { get; private set; }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    public abstract void OnTriggerEnter(Collider other);
    public abstract void OnTriggerStay(Collider other);
    public abstract void OnTriggerExit(Collider other);
}
