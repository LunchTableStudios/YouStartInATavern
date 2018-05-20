using UnityEngine;

namespace YouStartInATavern
{
    public class GameManager : MonoBehaviour
    {
        // Singleton Reference
        public static GameManager Instance{ get; private set; }

        void Awake()
        {
            if( Instance == null )
                Instance = this;
            else if( Instance != this )
                Destroy( gameObject );
        }

        
    }
}