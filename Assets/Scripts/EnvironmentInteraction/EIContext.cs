using UnityEngine;
using UnityEngine.Animations.Rigging;

public enum BodySide {

    Left,
    Right,
}

public class EIContext {

    private TwoBoneIKConstraint leftHandIKConstraint;
    private TwoBoneIKConstraint rightHandIKConstraint;
    private MultiRotationConstraint leftHandMRConstraint;
    private MultiRotationConstraint rightHandMRConstraint;
    private CharacterController characterController;
    private Transform rootTransform;
    private Vector3 leftTargetOriginalPosition;
    private Vector3 rightTargetOriginalPosition;

    public TwoBoneIKConstraint LeftHandIKConstratint => leftHandIKConstraint;
    public TwoBoneIKConstraint RightHandIKConstraint => rightHandIKConstraint;
    public MultiRotationConstraint LeftHandMRConstraint => leftHandMRConstraint;
    public MultiRotationConstraint RightHandMRConstraint => rightHandMRConstraint;
    public CharacterController CharacterController => characterController;
    public Transform RootTransform => rootTransform;

    public BodySide CurrentBodySide { get; private set; }
    public TwoBoneIKConstraint CurrentIKConstraint { get; private set; }
    public MultiRotationConstraint CurrentMRConstraint { get; private set; }
    public Transform CurrentShoulderTransform { get; private set; }
    public Transform CurrentTargetTransform { get; private set; }
    public Collider CurrentCollider { get; set; }
    public Vector3 ClosestPointFromShoulder { get; set; } = Vector3.positiveInfinity;
    public float CharacterShoulderHeight { get; private set; }
    public float TargetPointYOffset { get; set; } = 0f;
    public float ColliderCenterY { get; set; }
    public Vector3 CurrentTargetOriginalPosition { get; private set; }
    public Quaternion TargetOriginalRotation { get; private set; }

    public EIContext(TwoBoneIKConstraint leftHandIKConstraint, TwoBoneIKConstraint rightHandIKConstraint, MultiRotationConstraint leftHandMRConstraint, MultiRotationConstraint rightHandMRConstraint, CharacterController characterController, Transform rootTransform) {

        this.leftHandIKConstraint = leftHandIKConstraint;
        this.rightHandIKConstraint = rightHandIKConstraint;
        this.leftHandMRConstraint = leftHandMRConstraint;
        this.rightHandMRConstraint = rightHandMRConstraint;
        this.characterController = characterController;
        this.rootTransform = rootTransform;
        leftTargetOriginalPosition = leftHandIKConstraint.data.target.transform.localPosition;
        rightTargetOriginalPosition = rightHandIKConstraint.data.target.transform.localPosition;
        TargetOriginalRotation = leftHandIKConstraint.data.target.rotation;

        CharacterShoulderHeight = leftHandIKConstraint.data.root.transform.position.y;

        SetCurrentBodySide(Vector3.positiveInfinity);
    }

    public void SetCurrentBodySide(Vector3 targetPosition) {

        Vector3 leftShoulder = leftHandIKConstraint.data.root.transform.position;
        Vector3 rightShoulder = rightHandIKConstraint.data.root.transform.position;

        bool isLeftShoulderCloser = Vector3.Distance(leftShoulder, targetPosition) < Vector3.Distance(rightShoulder, targetPosition);

        if(isLeftShoulderCloser) {

            Debug.Log($"Left side");
            CurrentBodySide = BodySide.Left;
            CurrentIKConstraint = leftHandIKConstraint;
            CurrentMRConstraint = leftHandMRConstraint;
            CurrentTargetOriginalPosition = leftTargetOriginalPosition;

        } else {

            Debug.Log($"Right side");
            CurrentBodySide = BodySide.Right;
            CurrentIKConstraint = rightHandIKConstraint;
            CurrentMRConstraint = rightHandMRConstraint;
            CurrentTargetOriginalPosition = rightTargetOriginalPosition;
        }

        CurrentShoulderTransform = CurrentIKConstraint.data.root.transform;
        CurrentTargetTransform = CurrentIKConstraint.data.target.transform;
    }
}
