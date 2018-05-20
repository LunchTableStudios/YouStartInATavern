using UnityEngine;

namespace YouStartInATavern.Tavern
{

    using Utilities.SceneManagement;

    public class TavernSceneController : SceneController
    {
        public override void OnAfterSceneLoad()
        {

            Debug.Log( "Tavern generated" );
            // TODO : Generate Tavern

            // After Tavern Generates
            base.OnAfterSceneLoad();
        }
    }
}