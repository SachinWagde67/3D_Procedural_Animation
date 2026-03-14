using UnityEngine;
using UnityEngine.Animations.Rigging;

public enum EIStateEnum {

    Search,
    Approach,
    Rise,
    Touch,
    Reset
}

public class EIStateMachine : StateManager<EIStateEnum> {

    [SerializeField] private TwoBoneIKConstraint leftHandIKConstraint;
    [SerializeField] private TwoBoneIKConstraint rightHandIKConstraint;
    [SerializeField] private MultiRotationConstraint leftHandMRConstraint;
    [SerializeField] private MultiRotationConstraint rightHandMRConstraint;
    [SerializeField] private CharacterController characterController;

    private EIContext context;

    private void Awake() {

        context = new EIContext(leftHandIKConstraint, rightHandIKConstraint, leftHandMRConstraint, rightHandMRConstraint, characterController, transform.root);

        SetCharacterColliderCenter();
        InitializeStates();
    }

    private void InitializeStates() {

        statesMap.Add(EIStateEnum.Search, new SearchState(context, EIStateEnum.Search, this));
        statesMap.Add(EIStateEnum.Approach, new ApproachState(context, EIStateEnum.Approach, this));
        statesMap.Add(EIStateEnum.Rise, new RiseState(context, EIStateEnum.Rise, this));
        statesMap.Add(EIStateEnum.Touch, new TouchState(context, EIStateEnum.Touch, this));
        statesMap.Add(EIStateEnum.Reset, new ResetState(context, EIStateEnum.Reset, this));
        CurrentState = statesMap[EIStateEnum.Reset];
        ChangeStateTo(EIStateEnum.Reset);
    }

    public void ChangeStateTo(EIStateEnum newState) {
        ChangeState(newState);
    }

    private void SetCharacterColliderCenter() {

        context.ColliderCenterY = characterController.transform.position.y + characterController.center.y;
    }

    private void OnDrawGizmos() {

        Gizmos.color = Color.blueViolet;

        if(context != null && context.ClosestPointFromShoulder != null) {

            Gizmos.DrawSphere(context.ClosestPointFromShoulder, 0.1f);
        }
    }
}
