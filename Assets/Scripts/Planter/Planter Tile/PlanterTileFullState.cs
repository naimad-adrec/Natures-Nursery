using UnityEngine;

public class PlanterTileFullState : PlanterTileBaseState
{
    public override void EnterState(PlanterTileStateManager tile)
    {
        tile.Plant.SetActive(true);
        tile.IsPlanted = true;
    }

    public override void UpdateState(PlanterTileStateManager tile)
    {
        if (tile.IsPlanted == true)
        {

        }
        else
        {
            tile.SwitchState(tile.FullState);
        }
    }

    public override void OnCollisionEnter2D(PlanterTileStateManager player)
    {

    }
}
