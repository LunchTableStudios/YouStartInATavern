using UnityEngine;

namespace YouStartInATavern
{
    using Framework.Input;
    using Gameplay.PlayerCharacter; 

    public class GameManager : MonoBehaviour
    {
        // Singleton Reference
        public static GameManager Instance{ get; private set; }

        #region Public Properties
        public InputManager inputManager{ get; private set; }
        public PlayerManager playerManager{ get; private set; }
        #endregion

        void Awake()
        {
            if( Instance == null )
                Instance = this;
            else if( Instance != this )
                Destroy( gameObject );
        }

        void Start()
        {
            inputManager = new InputManager();
            playerManager = new PlayerManager();
        }

        void Update()
        {
            playerManager.OnUpdate();
        }
    }
}