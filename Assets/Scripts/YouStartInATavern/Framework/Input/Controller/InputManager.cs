namespace YouStartInATavern.Framework.Input
{
    using Rewired;

    public class InputManager
    {
        public void ResetControllerAssignments()
        {
            foreach( Joystick joystick in ReInput.controllers.Joysticks )
            {
                ReInput.players.GetSystemPlayer().controllers.AddController( joystick, true );
            }
        }
    }
}