namespace YouStartInATavern.Framework.StateManagement
{
    [ System.Serializable ]
    public class StateMachine
    {
        public State currentState;

        public void UpdateState()
        {
            currentState.OnUpdate( this );
        }

        public void ChangeState( State _newState )
        {
            currentState = _newState;
        }
    }
}