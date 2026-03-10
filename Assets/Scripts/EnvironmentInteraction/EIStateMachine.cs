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
        InitializeStates();
    }

    private void InitializeStates() {

        statesMap.Add(EIStateEnum.Search, new SearchState(context, EIStateEnum.Search));
        statesMap.Add(EIStateEnum.Approach, new ApproachState(context, EIStateEnum.Approach));
        statesMap.Add(EIStateEnum.Rise, new RiseState(context, EIStateEnum.Rise));
        statesMap.Add(EIStateEnum.Touch, new TouchState(context, EIStateEnum.Touch));
        statesMap.Add(EIStateEnum.Reset, new ResetState(context, EIStateEnum.Reset));
        CurrentState = statesMap[EIStateEnum.Reset];
        ChangeState(EIStateEnum.Search);
    }

    private void OnDrawGizmos() {

        Gizmos.color = Color.blueViolet;

        if(context != null && context.ClosestPointFromShoulder != null) {
            Gizmos.DrawSphere(context.ClosestPointFromShoulder, 0.1f);
        }
    }
}
