namespace YouStartInATavern.Scenes.Tavern
{
    using UnityEngine;
    using Framework.SceneManagement;

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