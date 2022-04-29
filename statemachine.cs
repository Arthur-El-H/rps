public class statemachine
{
    public IState currentState;

    public void changeState(IState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    public void updateStateMachine()
    {
        if (currentState != null) currentState.Execute();
    }

    public IState getState()
    {
        return currentState;
    }
}