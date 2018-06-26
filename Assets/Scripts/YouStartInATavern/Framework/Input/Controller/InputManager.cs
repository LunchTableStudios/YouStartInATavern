namespace YouStartInATavern.Framework.Input
{
    using System.Collections.Generic;
    using Rewired;

    public class InputManager
    {

        public List<int> assignedJoysticks;

        public InputManager()
        {
            assignedJoysticks = new List<int>();
            ResetControllerAssignments();
            ReInput.ControllerConnectedEvent += OnControllerConnected;
        }

        private void OnControllerConnected( ControllerStatusChangedEventArgs _eventArgs )
        {
            if( _eventArgs.controllerType != ControllerType.Joystick ) return;
            ReInput.players.GetSystemPlayer().controllers.AddController( ReInput.controllers.GetJoystick( _eventArgs.controllerId ), true );
        }

        public void ResetControllerAssignments()
        {
            assignedJoysticks.Clear();
            foreach( Joystick joystick in ReInput.controllers.Joysticks )
            {
                ReInput.players.GetSystemPlayer().controllers.AddController( joystick, true );
            }
        }

        public void AssignKeyboardAndMouseToPlayer( Player _player )
        {
            _player.controllers.hasMouse = true;
            _player.controllers.hasKeyboard = true;
        }

        public void AssignJoystickToPlayer( Player _player, Joystick _joystick )
        {
            _player.controllers.AddController( _joystick, true );
            assignedJoysticks.Add( _joystick.id );
        }
    }
}