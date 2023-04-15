using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance;

    // State Variables
    PlayerBaseState CurrentState;
    public PlayerMovingState MovingState = new PlayerMovingState();
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerInteractingState InteractingState = new PlayerInteractingState();

    // Input Variables
    private Vector2 _playerInput;
    private float _dirY;
    private float _dirX;
    private float _lastDirX = 0f;
    private float _lastDirY = -1f;

    // Input Getters and Setters
    public Vector2 PlayerInput { get { return _playerInput; } set { _playerInput = value; } }
    public float DirX { get { return _dirX; } set { _dirX = value; } }
    public float DirY { get { return _dirY; } set { _dirY = value; } }
    public float LastDirX { get { return _lastDirX; } set { _lastDirX = value; } }
    public float LastDirY { get { return _lastDirY; } set { _lastDirY = value; } }

    // Game Components
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _coll;
    private Animator _animator;

    // Game Component Getter and Setters
    public Rigidbody2D RigidBody { get { return _rigidBody; } set { _rigidBody = value; } }
    public Animator Animator { get { return _animator; } set { _animator = value; } }

    // Item Variables
    private string[] _possibleItems = new string[] { "Watering Can", "Seed Bag", "Soil Bag", "Magnifying Glass", "Garden Shears" };
    private List<string> _currentItems = new List<string>(5);
    private string _currentItem;
    private int _currentItemIdx;
    private bool _isInteracting = false;
    private float _waterPercentage = 100f;
    private bool _isItemMenuClosed = false;

    // Interact Getters and Setters
    public bool IsInteracting { get { return _isInteracting; } set { _isInteracting = value; } }
    public string CurrentItem { get { return _currentItem; } set { _currentItem = value; } }
    public int CurrentItemIdx { get { return _currentItemIdx; } set { _currentItemIdx = value; } }
    public List<string> CurrentItems { get { return _currentItems; } set { _currentItems = value; } }
    public float WaterPercentage { get { return _waterPercentage; } set { _waterPercentage = value; } }
    public bool IsItemMenuClosed { get { return _isItemMenuClosed; } set { _isItemMenuClosed = value; } }

    // Resource Getters and Setters

    // Event Variables
    [SerializeField] private UnityEvent _openSeedBag;
    [SerializeField] private UnityEvent closeSeedBag;

    // Event Getters and Setters
    public UnityEvent OpenSeedBag { get { return _openSeedBag; } private set { } }

    private void Awake()
    {
        // Call Instance
        Instance = this;

        // Call Game Components
        _rigidBody = GetComponent<Rigidbody2D>();
        _coll = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();

        // Call Input System
        CustomInput customInput = new CustomInput();
        customInput.Player.Enable();
        customInput.Player.Movement.performed += OnMove;
        customInput.Player.Movement.canceled += OnMoveStop;
        customInput.Player.Interact.performed += OnInteract;
        customInput.Player.SwitchItems.performed += OnSwitchItem;

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

    private void OnInteract(InputAction.CallbackContext context)
    {
        // Stop movement and set correct animation direction
        if(CurrentState == IdleState)
        {
            _animator.SetBool("IsItemMenuClosed", false);
            _isInteracting = true;
        }
        else if(CurrentState == MovingState)
        {
            _animator.SetBool("IsItemMenuClosed", false);
            _lastDirX = _dirX;
            _lastDirY = _dirY;
            _rigidBody.velocity = Vector2.zero;
            _isInteracting = true;
        }
        else
        {
            CloseUIMenu();
        }
    }

    private void OnSwitchItem(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            // Switch item in a positive direction
            if (_currentItemIdx == _currentItems.Count - 1)
            {
                _currentItemIdx = 0;
                _currentItem = _currentItems[_currentItemIdx];
            }
            else
            {
                _currentItem = _currentItems[_currentItemIdx + 1];
                _currentItemIdx++;
            }
        }
        else
        {
            // Switch item in a negative direction
            if (_currentItemIdx == 0)
            {
                _currentItemIdx = _currentItems.Count - 1;
                _currentItem = _currentItems[_currentItemIdx];
            }
            else
            {
                _currentItem = _currentItems[_currentItemIdx - 1];
                _currentItemIdx--;
            }
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _playerInput = context.ReadValue<Vector2>();
        _dirX = _playerInput.x;
        _dirY = _playerInput.y;
        _playerInput = _playerInput.normalized;
    }

    private void OnMoveStop(InputAction.CallbackContext context)
    {
        _lastDirX = _dirX;
        _lastDirY = _dirY;
        _playerInput = Vector2.zero;
        _dirX = 0;
        _dirY = 0;
    }

    public void CloseUIMenu()
    {
        _isInteracting = false;
        closeSeedBag.Invoke();
        _animator.SetBool("IsItemMenuClosed", true);
        _animator.SetBool("IsInteracting", false);
    }
}