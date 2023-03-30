using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterTileStateManager : MonoBehaviour
{
    // State Variables
    PlanterTileBaseState CurrentState;
    public PlanterTileEmptyState EmptyState = new PlanterTileEmptyState();
    public PlanterTileFullState FullState = new PlanterTileFullState();

    // Sprite Variables
    private SpriteRenderer sp;
    [SerializeField] private Sprite _dryTile;
    public Sprite DryTile { get; private set; }
    [SerializeField] private Sprite _wateredTile;
    public Sprite WateredTile { get; private set; }

    // Plant Variables
    private bool _isPlanted;
    public bool IsPlanted { get { return _isPlanted; } set { _isPlanted = value; } }

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        CurrentState = EmptyState;
        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    private void Update()
    {
        CurrentState.UpdateState(this);
    }
    public void SwitchState(PlanterTileBaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }

    private void OnMouseDown()
    {
        sp.sprite = _wateredTile;
    }
}
