using Unity.VisualScripting;
using UnityEngine;

public class PlanterTileEmptyState : PlanterTileBaseState
{
    public override void EnterState(PlanterTileStateManager tile)
    {
        Debug.Log("Im Empty");
        tile.IsPlanted = false;
    }

    public override void UpdateState(PlanterTileStateManager tile)
    {
        if (tile.IsPlanted == false)
        {
            CheckForInteract(tile);
        }
        else
        {
            tile.SwitchState(tile.FullState);
        }
    }

    public override void OnCollisionEnter2D(PlanterTileStateManager player)
    {

    }

    private void CheckForInteract(PlanterTileStateManager tile)
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            tile.IsPlanted = true;
        }
    }
}
