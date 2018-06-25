namespace YouStartInATavern.Framework.State
{
    using UnityEngine;

    [ CreateAssetMenu( menuName = "You Start in a Tavern/State Management/Pluggable State" ) ]
    public class State : ScriptableObject
    {
        public Action[] actions;

        public void UpdateState( PluggableStateMachine _machine )
        {
            foreach( Action action in actions )
            {
                action.Call( _machine );
            }
        }
    } 
}