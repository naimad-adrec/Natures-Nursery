public class PlantStateFactory 
{
    PlantStateMachine _context;

    public PlantStateFactory (PlantStateMachine context)
    {
        _context = context;
    }

    public PlantBaseState Infested()
    {
        return new PlantInfestedState(_context, this);
    }

    public PlantBaseState Healthy()
    {
        return new PlantHealthyState(_context, this);
    }

    public PlantBaseState Growing()
    {
        return new PlantGrowingState(_context, this);
    }

    public PlantBaseState Mature()
    {
        return new PlantMatureState(_context, this);
    }

    public PlantBaseState Dead()
    {
        return new PlantDeadState(_context, this);
    }
}