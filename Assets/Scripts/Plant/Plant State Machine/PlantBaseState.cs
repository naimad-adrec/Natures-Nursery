public abstract class PlantBaseState
{
    private bool _isRootState = false;
    private PlantStateMachine _ctx;
    private PlantStateFactory _factory;
    private PlantBaseState _currentSubState;
    private PlantBaseState _currentSuperState;

    protected bool IsRootState { set { _isRootState = value; } }
    protected PlantStateMachine Ctx { get { return _ctx; } }
    protected PlantStateFactory Factory { get { return _factory; } }

    public PlantBaseState (PlantStateMachine currentContext, PlantStateFactory plantStateFactory)
    {
        _ctx = currentContext;
        _factory = plantStateFactory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();

    public abstract void ExitState();

    public abstract void CheckSwitchStates();

    public abstract void InitializeSubState();

    public void UpdateStates()
    {
        UpdateState();
        if (_currentSubState != null)
        {
            _currentSubState.UpdateStates();
        }
    }

    protected void SwitchState(PlantBaseState newState)
    {
        // Current state exits state
        ExitState();

        // Enter new state
        newState.EnterState();

        // Switch current state of context
        if (_isRootState)
        {
            _ctx.CurrentState = newState;
        }
        else if (_currentSubState == null)
        {
            _currentSuperState.SetSubState(newState);
        }

    }

    protected void SetSubState(PlantBaseState newSubState)
    {
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }

    protected void SetSuperState(PlantBaseState newSuperState)
    {
        _currentSuperState = newSuperState;
    }
}