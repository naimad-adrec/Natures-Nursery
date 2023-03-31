using UnityEngine;

public class PlantHealthyState : PlantBaseState
{
    public PlantHealthyState(PlantStateMachine currentContext, PlantStateFactory plantStateFactory) : base(currentContext, plantStateFactory)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void EnterState()
    {
        Debug.Log("I am Healthy");
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
        if(Ctx.IsMature == false && Ctx.IsDead == false)
        {
            SetSubState(Factory.Growing());
        }
        else if(Ctx.IsMature == true && Ctx.IsDead == false)
        {
            SetSubState(Factory.Mature());
        }
        else
        {
            SetSubState(Factory.Dead());
        }
    }
}