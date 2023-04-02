using UnityEngine;

public class PlantMatureState : PlantBaseState
{
    public PlantMatureState(PlantStateMachine currentContext, PlantStateFactory plantStateFactory) : base(currentContext, plantStateFactory)
    {

    }

    public override void EnterState()
    {
        Ctx.IsMature = true;
        Ctx.IsDead = false;
        Debug.Log("I am Mature");
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
        if (Ctx.IsDead == true)
        {
            SwitchState(Factory.Dead());
        }
    }

    public override void InitializeSubState()
    {

    }
}