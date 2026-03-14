using UnityEngine;

public class ApproachState : EIState {

    private EIStateMachine eIStateMachine;

    private float elapsedTime = 0f;
    private float lerpDuration = 5f;
    private float weightToApproach = 0.5f;
    private float rotationSpeed = 500f;
    private float weightToApproachRotation = 0.75f;
    private float riseDistanceThreshold = 0.5f;
    private float approchStateDuration = 5f;

    public ApproachState(EIContext context, EIStateEnum eIStateEnum, EIStateMachine stateMachine) : base(context, eIStateEnum) {

        this.eIStateMachine = stateMachine;
    }

    public override void EnterState() {

        elapsedTime = 0f;
    }

    public override void UpdateState() {

        Quaternion groundRotation = Quaternion.LookRotation(-Vector3.up, context.RootTransform.forward);

        context.CurrentTargetTransform.rotation =
            Quaternion.RotateTowards(context.CurrentTargetTransform.rotation, groundRotation, rotationSpeed * Time.deltaTime);

        elapsedTime += Time.deltaTime;

        context.CurrentIKConstraint.weight = Mathf.Lerp(context.CurrentIKConstraint.weight, weightToApproach, elapsedTime / lerpDuration);
        context.CurrentMRConstraint.weight = Mathf.Lerp(context.CurrentMRConstraint.weight, weightToApproachRotation, elapsedTime / lerpDuration);

        float armsToTargetPointDistance = Vector3.Distance(context.ClosestPointFromShoulder, context.CurrentShoulderTransform.position);

        if(elapsedTime > approchStateDuration) {
            eIStateMachine.ChangeStateTo(EIStateEnum.Reset);
        }

        if(armsToTargetPointDistance < riseDistanceThreshold) {

            if(context.ClosestPointFromShoulder != Vector3.positiveInfinity) {

                eIStateMachine.ChangeStateTo(EIStateEnum.Rise);
            }
        }
    }

    public override void ExitState() { }

    public override void OnTriggerEnter(Collider other) {
        StartTrackingTargetPosition(other);
    }

    public override void OnTriggerExit(Collider other) {
        UpdateTargetPosition(other);
    }

    public override void OnTriggerStay(Collider other) {
        ResetTrackingTargetPosition(other);
    }
}
