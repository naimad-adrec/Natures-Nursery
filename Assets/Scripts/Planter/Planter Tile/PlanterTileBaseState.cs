using UnityEngine;

public abstract class PlanterTileBaseState
{
    public abstract void EnterState(PlanterTileStateManager tile);

    public abstract void UpdateState(PlanterTileStateManager tile);

    public abstract void OnCollisionEnter2D(PlanterTileStateManager tile);
}
