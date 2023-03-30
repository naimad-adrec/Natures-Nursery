using Unity.VisualScripting;
using UnityEngine;

public class PlanterTileEmptyState : PlanterTileBaseState
{
    public override void EnterState(PlanterTileStateManager tile)
    {
        Debug.Log("Im Empty");
    }

    public override void UpdateState(PlanterTileStateManager tile)
    {
        if (true)
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
