namespace YouStartInATavern.Gameplay.Characters.Player
{
    using Framework.StateManagement;
    using Rewired;

    [ System.Serializable ]
    public class PlayerController : StateMachine
    {
        public Player player;

        public bool isActive
        {
            get
            {
                return ( player.controllers.joystickCount > 0 || ( player.controllers.hasKeyboard && player.controllers.hasMouse ) );
            }
        }

    }
}