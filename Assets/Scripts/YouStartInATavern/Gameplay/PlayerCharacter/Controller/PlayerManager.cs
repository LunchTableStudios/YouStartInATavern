namespace YouStartInATavern.Gameplay.PlayerCharacter
{
    using Rewired;

    [ System.Serializable ]
    public class PlayerManager
    {

        #region Inspector Properties
        public int maxPlayers = 1;
        #endregion

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

        public void Initialize()
        {
            players = new PlayerController[4];

            for( int i = 0; i < players.Length; i++ )
            {
                players[i] = new PlayerController( i );
            }
        }
        
    }
}