namespace YouStartInATavern.Gameplay.Characters.Player
{
    using Framework;
    using Rewired;

    public class PlayerManager : Singleton<PlayerManager>
    {
        public PlayerController[] playerControllers;

        public int NextInactivePlayerId
        {
            get
            {
                for( int i = 0; i < playerControllers.Length; i++ )
                    if( !playerControllers[i].isActive ) return i;

                return -1;
            }
        }

        void Start()
        {
            playerControllers = new PlayerController[ ReInput.players.playerCount ];
            for( int i = 0; i < playerControllers.Length; i++ )
            {
                playerControllers[i].player = ReInput.players.GetPlayer( i );
            }
        }

        void Update()
        {
            for( int i = 0; i < playerControllers.Length; i++ )
            {
                playerControllers[i].UpdateState();
            }
        }
    }
}