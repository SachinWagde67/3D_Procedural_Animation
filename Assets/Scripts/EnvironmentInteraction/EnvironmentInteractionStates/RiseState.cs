using UnityEngine;

public class RiseState : EIState {

    public RiseState(EIContext context, EIStateEnum eIStateEnum) : base(context, eIStateEnum) {

    }

    public override void EnterState() { }
    public override void UpdateState() { }
    public override void ExitState() { }

    public override EIStateEnum GetNextState() {
        return State;
    }

    public override void OnTriggerEnter(Collider other) { }

    public override void OnTriggerExit(Collider other) { }

    public override void OnTriggerStay(Collider other) { }
}
