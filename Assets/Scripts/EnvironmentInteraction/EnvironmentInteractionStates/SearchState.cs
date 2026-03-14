using UnityEngine;

public class SearchState : EIState {

    private EIStateMachine eIStateMachine;
    private float approachDistance = 2f;

    public SearchState(EIContext context, EIStateEnum eIStateEnum, EIStateMachine stateMachine) : base(context, eIStateEnum) {

        this.eIStateMachine = stateMachine;
    }

    public override void EnterState() { }

    public override void UpdateState() {

        float distance = Vector3.Distance(context.ClosestPointFromShoulder, context.RootTransform.position);

        if(distance < approachDistance) {

            if(context.ClosestPointFromShoulder != Vector3.positiveInfinity) {

                eIStateMachine.ChangeStateTo(EIStateEnum.Approach);
            }
        }
    }

    public override void ExitState() { }

    public override void OnTriggerEnter(Collider other) {

        StartTrackingTargetPosition(other);
    }

    public override void OnTriggerExit(Collider other) {

        ResetTrackingTargetPosition(other);
    }

    public override void OnTriggerStay(Collider other) {

        UpdateTargetPosition(other);
    }
}
