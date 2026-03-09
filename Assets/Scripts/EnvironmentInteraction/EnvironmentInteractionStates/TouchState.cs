using UnityEngine;

public class TouchState : EIState {

    public TouchState(EIContext context, EIStateEnum eIStateEnum) : base(context, eIStateEnum) {

    }

    public override void EnterState() { }

    public override void ExitState() { }

    public override EIStateEnum GetNextState() {
        return State;
    }

    public override void OnTriggerEnter(Collider other) { }

    public override void OnTriggerExit(Collider other) { }

    public override void OnTriggerStay(Collider other) { }

    public override void UpdateState() { }
}
