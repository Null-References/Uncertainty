namespace NPC.Enemy_AI.StateMachine
{
    public interface IState
    {
        void Enter();
        IState ProcessTransition();
        void Exit();
    }
}