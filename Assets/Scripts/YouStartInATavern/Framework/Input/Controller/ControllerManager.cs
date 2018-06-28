namespace YouStartInATavern.Framework.Input
{
    using System.Collections.Generic;
    using Rewired;

    public static class ControllerManager
    {
        private static List<int> assignedControllers = new List<int>();

        public static void ResetAllControllers()
        {
            foreach( Joystick joystick in ReInput.controllers.Joysticks )
            {
                ReInput.players.GetSystemPlayer().controllers.AddController( joystick, true );
            }
        }

    }
}