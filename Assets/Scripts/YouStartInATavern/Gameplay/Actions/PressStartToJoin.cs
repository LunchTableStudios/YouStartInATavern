namespace YouStartInATavern.Gameplay
{
    using System.Collections.Generic;
    using UnityEngine;
    using Rewired;
    using Framework.State;

    [ CreateAssetMenu( menuName = "You Start in a Tavern/State Management/Actions/Press Start to Join" ) ]
    public class PressStartToJoinAction : Action
    {
        public override void Call( PluggableStateMachine _machine )
        {
            if( ReInput.players.GetSystemPlayer().GetButtonDown( "Join Game" ) )
            {
                int nextPlayerID = GameManager.Instance.playerManager.NextInactivePlayer;
                if( nextPlayerID != -1 )
                {
                    Player nextPlayer = ReInput.players.GetPlayer( nextPlayerID + 1 );
                    IList<InputActionSourceData> inputSources = ReInput.players.GetSystemPlayer().GetCurrentInputSources( "Join Game" );
                    foreach( InputActionSourceData source in inputSources )
                    {
                        if( !GameManager.Instance.inputManager.assignedJoysticks.Contains( source.controller.id ) )
                        {
                            if( source.controllerType == ControllerType.Joystick )
                                GameManager.Instance.inputManager.AssignJoystickToPlayer( nextPlayer, source.controller as Joystick );

                            break;
                        }
                    }
                }
            }
        }
    }
}