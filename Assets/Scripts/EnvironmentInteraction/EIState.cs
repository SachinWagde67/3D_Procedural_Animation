using UnityEngine;

public abstract class EIState : BaseState<EIStateEnum> {

    protected EIContext context;

    public EIState(EIContext context, EIStateEnum eIStateEnum) : base(eIStateEnum) {
        this.context = context;
    }

    private Vector3 GetClosestPoint(Collider collider, Vector3 fromPosition) {

        return collider.ClosestPoint(fromPosition);
    }

    protected void StartTrackingTargetPosition(Collider collider) {

        bool isInteractableLayer = collider.gameObject.layer == LayerMask.NameToLayer("Interactable");
        bool isCurrentColliderNull = context.CurrentCollider == null;

        if(isInteractableLayer && isCurrentColliderNull) {

            context.CurrentCollider = collider;
            Vector3 closePoint = GetClosestPoint(collider, context.RootTransform.position);
            context.SetCurrentBodySide(closePoint);

            SetTargetPosition();
        }
    }

    protected void UpdateTargetPosition(Collider collider) {

        if(collider == context.CurrentCollider) {
            SetTargetPosition();
        }
    }

    protected void ResetTrackingTargetPosition(Collider collider) {

        if(collider == context.CurrentCollider) {

            context.CurrentCollider = null;
            context.ClosestPointFromShoulder = Vector3.positiveInfinity;
        }
    }

    private void SetTargetPosition() {

        float x = context.CurrentShoulderTransform.position.x;
        float y = context.CharacterShoulderHeight;
        float z = context.CurrentShoulderTransform.position.z;

        Vector3 shoulderPosition = new Vector3(x, y, z);

        context.ClosestPointFromShoulder = GetClosestPoint(context.CurrentCollider, shoulderPosition);
    }
}
