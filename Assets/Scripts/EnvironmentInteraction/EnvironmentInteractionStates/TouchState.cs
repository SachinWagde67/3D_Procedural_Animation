using UnityEngine;

public class TouchState : EIState {

    private EIStateMachine eIStateMachine;

    public TouchState(EIContext context, EIStateEnum eIStateEnum, EIStateMachine stateMachine) : base(context, eIStateEnum) {

        this.eIStateMachine = stateMachine;
    }

    public override void EnterState() { }
    public override void UpdateState() { }
    public override void ExitState() { }

    public override void OnTriggerEnter(Collider other) { }

    public override void OnTriggerExit(Collider other) { }

    public override void OnTriggerStay(Collider other) { }
}
