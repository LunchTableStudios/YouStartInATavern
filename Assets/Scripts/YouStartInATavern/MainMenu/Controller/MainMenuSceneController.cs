using UnityEngine;
using UnityEngine.UI;

namespace YouStartInATavern.MainMenu
{
    using Utilities.SceneManagement;
    using Rewired;

    public class MainMenuSceneController : SceneController
    {
        private Canvas canvas;
        public Button[] buttons;

        void Awake()
        {
            canvas = gameObject.GetComponentInChildren<Canvas>();
            buttons = canvas.GetComponentsInChildren<Button>();
            
            
        }

        void Start()
        {
            buttons[0].Select();
        }

        void Update()
        {
            for( int i = 0; i < ReInput.players.playerCount; i++ )
            {
                if( ReInput.players.GetPlayer( i ).GetButtonDown( "Menu Up" ) )
                {
                    Debug.Log( "UP" );
                }
            }
        }
    }
}