namespace YouStartInATavern.Gameplay
{
    using UnityEngine;
    using Rewired;
    using Framework.State;

    [ CreateAssetMenu( menuName = "You Start in a Tavern/State Management/Actions/Press Start to Join" ) ]
    public class PressStartToJoinAction : Action
    {
        public override void Call( PluggableStateMachine _machine )
        {
            foreach( Joystick joystick in ReInput.players.GetSystemPlayer().controllers.Joysticks )
            {
                if( joystick.GetAnyButtonDown() )
                {
                    
                }
            }
        }
    }
}