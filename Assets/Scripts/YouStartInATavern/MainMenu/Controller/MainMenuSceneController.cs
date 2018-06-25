using UnityEngine;
using UnityEngine.UI;

namespace YouStartInATavern.MainMenu
{
    using Utilities.SceneManagement;
    using Rewired;

    public class MainMenuSceneController : SceneController
    {

        #region Private Properties
        private Canvas canvas;
        private Button[] buttons;
        private Button selectedButton;
        #endregion

        void Awake()
        {
            canvas = gameObject.GetComponentInChildren<Canvas>();
            buttons = canvas.GetComponentsInChildren<Button>();
        }

        void Start()
        {
            SetSelectedButton(0);
        }

        void Update()
        {
            if( ReInput.players.SystemPlayer.GetButtonDown( "Menu Up" ) )
                SetSelectedButton( System.Array.IndexOf( buttons, selectedButton ) - 1 );
            else if( ReInput.players.SystemPlayer.GetButtonDown( "Menu Down" ) )
                SetSelectedButton( System.Array.IndexOf( buttons, selectedButton ) + 1 );
        }

        public void SetSelectedButton( int _index )
        {
            if( _index < 0 || _index >= buttons.Length ) return;

            selectedButton = buttons[_index];
            selectedButton.Select();
        }
    }
}