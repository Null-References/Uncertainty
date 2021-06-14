public interface IState
{
    void Enter();
    IState ProcessTransition();
    void Exit();
}