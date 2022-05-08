public interface IState
{
    void init();
    void Execute();
    void Exit();
    void handleInput(IInput input);
}