using UnityEngine;

public class PlantGrowingState : PlantBaseState
{
    public PlantGrowingState(PlantStateMachine currentContext, PlantStateFactory plantStateFactory) : base(currentContext, plantStateFactory)
    {

    }

    public override void EnterState()
    {
        Ctx.SpriteRenderer.sprite = Ctx.GrowthStageOne;
        Ctx.IsMature = false;
        Ctx.IsDead = false;
        Debug.Log("I am growing");
    }

    public override void UpdateState()
    {
        //Debug.Log("I am growing");
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
        else if (Ctx.IsMature == true)
        {
            SwitchState(Factory.Mature());
        }
    }

    public override void InitializeSubState()
    {

    }
}