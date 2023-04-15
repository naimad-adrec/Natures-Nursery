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
    [SerializeField] private Sprite dryTile;
    [SerializeField] private Sprite wateredTile;

    // Plant Variables
    private GameObject _plant;
    private bool _isPlanted;

    // Watered Variables
    private bool _isWatered = false;

    // Getters and Setters
    public GameObject Plant { get { return _plant; } set { _plant = value; } }
    public bool IsPlanted { get { return _isPlanted; } set { _isPlanted = value; } }
    public bool IsWatered { get { return _isWatered; } set { _isWatered = value; } }


    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        _plant = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        CurrentState = EmptyState;
        CurrentState.EnterState(this);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
        CheckIfTileIsWatered();
    }

    public void SwitchState(PlanterTileBaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }

    private void CheckIfTileIsWatered()
    {
        if (_isWatered == false)
        {
            sp.sprite = dryTile;
        }
        else
        {
            sp.sprite = wateredTile;
        }
    }
}
