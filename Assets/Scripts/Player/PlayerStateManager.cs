using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // State Variables
    PlayerBaseState CurrentState;
    public PlayerMovingState MovingState = new PlayerMovingState();
    public PlayerIdleState IdleState = new PlayerIdleState();

    // Game Components
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _coll;
    private Animator _animator;

    // Getter and Setters
    public Rigidbody2D RigidBody { get { return _rigidBody; } set { _rigidBody = value; } }
    public Animator Animator { get { return _animator; } set { _animator = value; } }

    private void Awake()
    {
        // Call Game Components
        _rigidBody = GetComponent<Rigidbody2D>();
        _coll = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        // Starting state for the state machine
        CurrentState = IdleState;
        // Reference to the apples context (This exact monobehavior script)
        CurrentState.EnterState(this);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }
}
