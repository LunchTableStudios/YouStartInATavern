namespace YouStartInATavern.Framework.State
{
    using UnityEngine;

    public class PluggableStateMachine : MonoBehaviour
    {
        public State currentState;

        void Update()
        {
            currentState.UpdateState( this );
        }
    }
}