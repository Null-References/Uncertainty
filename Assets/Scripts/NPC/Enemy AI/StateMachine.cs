public class StateMachine
{
        private IState _currentState;
        public void ChangeState(IState newState)
        {
                if (_currentState != null)
                        _currentState.Exit();
 
                _currentState = newState;
                _currentState.Enter();
        }
 
        public void Update()
        {
             //   if (_currentState != null) _currentState.Execute();
        }
    public void Tick()
    {

    }
}