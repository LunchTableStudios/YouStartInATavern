using UnityEngine;

namespace YouStartInATavern
{
    using Framework.Input;
    using Gameplay.Player; 

    public class GameManager : MonoBehaviour
    {
        // Singleton Reference
        public static GameManager Instance{ get; private set; }

        #region Public Properties
        public InputManager input{ get; private set; }
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
            input.ResetControllerAssignments();
        }
    }
}