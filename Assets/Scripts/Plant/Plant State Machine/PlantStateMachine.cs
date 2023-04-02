using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStateMachine : MonoBehaviour
{
    // State Variables
    private PlantBaseState _currentState;
    private PlantStateFactory _states;

    // Growth Variables
    private bool _isMature = false;
    private bool _isDead = false;

    // Getters and Setters
    public PlantBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public bool IsMature { get { return _isMature; } set { _isMature = value; } }
    public bool IsDead { get { return _isDead; } set { _isDead = value; } }

    private void Awake()
    {
        // State Initialization
        _states = new PlantStateFactory(this);
        _currentState = _states.Healthy();
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdateStates();
    }
}