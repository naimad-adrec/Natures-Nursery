using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance;

    // State Variables
    PlayerBaseState CurrentState;
    public PlayerMovingState MovingState = new PlayerMovingState();
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerInteractingState InteractingState = new PlayerInteractingState();

    // Game Components
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _coll;
    private Animator _animator;

    // Component Getter and Setters
    public Rigidbody2D RigidBody { get { return _rigidBody; } set { _rigidBody = value; } }
    public Animator Animator { get { return _animator; } set { _animator = value; } }

    // Movement Variables
    private float _lastDirX = 0f;
    private float _lastDirY = -1f;

    // Movement Getters and Setters
    public float LastDirX { get { return _lastDirX; } set { _lastDirX = value; } }
    public float LastDirY { get { return _lastDirY; } set { _lastDirY = value; } }

    // Item Variables
    private string[] _possibleItems = new string[] { "Watering Can", "Seed Bag", "Soil Bag", "Magnifying Glass", "Garden Shears" };
    private List<string> _currentItems = new List<string>(5);
    private string _currentItem;
    private int _currentItemIdx;
    private bool _isInteracting = false;
    private float _waterPercentage = 100f;

    // Interact Getters and Setters
    public bool IsInteracting { get { return _isInteracting; } set { _isInteracting = value; } }
    public string CurrentItem { get { return _currentItem; } set { _currentItem = value; } }
    public int CurrentItemIdx { get { return _currentItemIdx; } set { _currentItemIdx = value; } }
    public List<string> CurrentItems { get { return _currentItems; } set { _currentItems = value; } }
    public float WaterPercentage { get { return _waterPercentage; } set { _waterPercentage = value; } }

    private void Awake()
    {
        // Call Instance
        Instance = this;

        // Call Game Components
        _rigidBody = GetComponent<Rigidbody2D>();
        _coll = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();

        // Set Current Items
        _currentItems.Add(_possibleItems[0]);
        _currentItems.Add(_possibleItems[1]);
        _currentItem = _currentItems[0];
        _currentItemIdx = 0;
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