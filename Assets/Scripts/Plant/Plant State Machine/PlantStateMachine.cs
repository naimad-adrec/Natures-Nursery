using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStateMachine : MonoBehaviour
{
    // State Variables
    private PlantBaseState _currentState;
    private PlantStateFactory _states;

    // Game Comopnent Variables
    [SerializeField] private Plant plant;
    private SpriteRenderer _spriteRenderer;

    // Plant Information Variables
    private string _plantName; 

    // Growth Variables
    private bool _isMature = false;
    private bool _isDead = false;
    private Sprite _growthStageOne;
    private Sprite _growthStageTwo;
    private Sprite _growthStageThree;
    private Sprite _growthStageFour;
    private Sprite _growthStageFive;
    private Sprite _growthMatureStage;

    // Getters and Setters
    public PlantBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public SpriteRenderer SpriteRenderer { get { return _spriteRenderer; } set { _spriteRenderer = value; } }
    public Sprite GrowthStageOne { get { return _growthStageOne; } private set { } }
    public Sprite GrowthStageTwo { get { return _growthStageTwo; } private set { } }
    public Sprite GrowthStageThree { get { return _growthStageThree; } private set { } }
    public Sprite GrowthStageFour { get { return _growthStageFour; } private set { } }
    public Sprite GrowthStageFive { get { return _growthStageFive; } private set { } }
    public Sprite GrowthMatureStage { get { return _growthMatureStage; } private set { } }
    public bool IsMature { get { return _isMature; } set { _isMature = value; } }
    public bool IsDead { get { return _isDead; } set { _isDead = value; } }

    private void Awake()
    {
        // State Initialization
        _states = new PlantStateFactory(this);
        _currentState = _states.Healthy();
        _currentState.EnterState();

        // Game Component Initialization
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // Plant Info Initilization
        _plantName = plant.PlantName;
        _growthStageOne = plant.PlantStageOneSprite;
        _growthStageTwo = plant.PlantStageTwoSprite;
        _growthStageThree = plant.PlantStageThreeSprite;
        _growthStageFour = plant.PlantStageFourSprite;
        _growthStageFive = plant.PlantStageFiveSprite;
        _growthMatureStage = plant.PlantMatureStage;
    }

    private void Start()
    {
        _spriteRenderer.sprite = _growthStageOne;
    }

    private void Update()
    {
        _currentState.UpdateStates();
    }
}