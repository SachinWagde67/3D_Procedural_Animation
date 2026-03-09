using UnityEngine;

public class SearchState : EIState {

    public SearchState(EIContext context, EIStateEnum eIStateEnum) : base(context, eIStateEnum) {

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
