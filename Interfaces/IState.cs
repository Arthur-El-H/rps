public interface IState
{
    void Enter();
    void Execute();
    void Exit();
    void handleInput(IInput input);
}