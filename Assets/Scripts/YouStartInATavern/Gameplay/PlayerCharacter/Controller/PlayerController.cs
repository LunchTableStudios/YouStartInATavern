namespace YouStartInATavern.Gameplay.PlayerCharacter
{
    using UnityEngine;
    using Rewired;

    public class PlayerController
    {
        public int id;
        public bool isActive
        {
            get
            {
                return ( rewiredPlayer.controllers.joystickCount > 0 || rewiredPlayer.controllers.hasKeyboard || rewiredPlayer.controllers.hasMouse );
            }
        }

        private Player rewiredPlayer;

        public PlayerController( int _id )
        {
            id = _id;
            rewiredPlayer = ReInput.players.GetPlayer( id );
        }

        public void OnUpdate()
        {
            
        }

    }
}