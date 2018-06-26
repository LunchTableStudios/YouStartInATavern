namespace YouStartInATavern.Gameplay.PlayerCharacter
{
    using UnityEngine;
    using Rewired;

    public class PlayerManager
    {
        #region Public Properties
        public int NextInactivePlayer
        {
            get
            {
                for( int i = 0; i < players.Length; i++ )
                    if( !players[i].isActive ) return i;

                return -1;
            }
        }
        #endregion

        private PlayerController[] players;

        public PlayerManager()
        {
            players = new PlayerController[ ReInput.players.allPlayerCount - 1 ];

            for( int i = 0; i < players.Length; i++ )
            {
                players[i] = new PlayerController( i );
            }
        }

        public void OnUpdate()
        {
            foreach( PlayerController player in players )
            {
                player.OnUpdate();
            }
        }
        
    }
}