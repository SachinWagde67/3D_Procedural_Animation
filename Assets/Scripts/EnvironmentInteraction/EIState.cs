using UnityEngine;

public abstract class EIState : BaseState<EIStateEnum> {

    protected EIContext context;

    public EIState(EIContext context, EIStateEnum eIStateEnum) : base(eIStateEnum) {
        this.context = context;
    }
}
