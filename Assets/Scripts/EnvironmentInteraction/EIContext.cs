using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EIContext {

    private TwoBoneIKConstraint leftHandIKConstraint;
    private TwoBoneIKConstraint rightHandIKConstraint;
    private MultiRotationConstraint leftHandMRConstraint;
    private MultiRotationConstraint rightHandMRConstraint;
    private CharacterController characterController;

    public EIContext(TwoBoneIKConstraint leftHandIKConstraint, TwoBoneIKConstraint rightHandIKConstraint, MultiRotationConstraint leftHandMRConstraint, MultiRotationConstraint rightHandMRConstraint, CharacterController characterController) {

        this.leftHandIKConstraint = leftHandIKConstraint;
        this.rightHandIKConstraint = rightHandIKConstraint;
        this.leftHandMRConstraint = leftHandMRConstraint;
        this.rightHandMRConstraint = rightHandMRConstraint;
        this.characterController = characterController;
    }

    public TwoBoneIKConstraint LeftHandIKConstratint => leftHandIKConstraint;
    public TwoBoneIKConstraint RightHandIKConstraint => rightHandIKConstraint;
    public MultiRotationConstraint LeftHandMRConstraint => leftHandMRConstraint;
    public MultiRotationConstraint RightHandMRConstraint => rightHandMRConstraint;
    public CharacterController CharacterController => characterController;
}
