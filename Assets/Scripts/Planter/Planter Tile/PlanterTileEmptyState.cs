using Unity.VisualScripting;
using UnityEngine;

public class PlanterTileEmptyState : PlanterTileBaseState
{
    public override void EnterState(PlanterTileStateManager tile)
    {
        tile.Plant.SetActive(false);
        tile.IsPlanted = false;
    }

    public override void UpdateState(PlanterTileStateManager tile)
    {
        if (tile.IsPlanted == false)
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
