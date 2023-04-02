using UnityEngine;

public class PlantDeadState : PlantBaseState
{
    public PlantDeadState(PlantStateMachine currentContext, PlantStateFactory plantStateFactory) : base(currentContext, plantStateFactory)
    {

    }

    public override void EnterState()
    {
        Ctx.IsDead = true;
        Debug.Log("I am Dead");
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {

    }

    public override void CheckSwitchStates()
    {

    }

    public override void InitializeSubState()
    {

    }
}