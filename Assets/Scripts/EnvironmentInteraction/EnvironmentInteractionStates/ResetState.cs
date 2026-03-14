using UnityEngine;

public class ResetState : EIState {

    private float elapsedTime = 0f;
    private float resetDuration = 2f;
    private float lerpDuration = 10f;
    private float rotationSpeed = 500f;

    private EIStateMachine eIStateMachine;

    public ResetState(EIContext context, EIStateEnum eIStateEnum, EIStateMachine stateMachine) : base(context, eIStateEnum) {

        this.eIStateMachine = stateMachine;
    }

    public override void EnterState() {

        elapsedTime = 0f;
        context.CurrentCollider = null;
        context.ClosestPointFromShoulder = Vector3.positiveInfinity;
    }

    public override void UpdateState() {

        elapsedTime += Time.deltaTime;

        context.TargetPointYOffset = Mathf.Lerp(context.TargetPointYOffset, context.ColliderCenterY, elapsedTime / lerpDuration);

        context.CurrentIKConstraint.weight = Mathf.Lerp(context.CurrentIKConstraint.weight, 0, elapsedTime / lerpDuration);
        context.CurrentMRConstraint.weight = Mathf.Lerp(context.CurrentMRConstraint.weight, 0, elapsedTime / lerpDuration);

        context.CurrentTargetTransform.localPosition =
            Vector3.Lerp(context.CurrentTargetTransform.localPosition, context.CurrentTargetOriginalPosition, elapsedTime / lerpDuration);

        context.CurrentTargetTransform.rotation =
            Quaternion.RotateTowards(context.CurrentTargetTransform.rotation, context.TargetOriginalRotation, rotationSpeed / lerpDuration);

        if(elapsedTime > resetDuration) {

            if(context.CharacterController.velocity != Vector3.zero) {

                eIStateMachine.ChangeStateTo(EIStateEnum.Search);
            }
        }
    }
    public override void ExitState() { }

    public override void OnTriggerEnter(Collider other) { }

    public override void OnTriggerExit(Collider other) { }

    public override void OnTriggerStay(Collider other) { }
}
