namespace YouStartInATavern.Framework.SceneManagement
{
    using UnityEngine;
    using LoadScreen;
    using State;

    public class SceneController : PluggableStateMachine
    {
        void OnEnable()
        {
            if( SceneChanger.Instance != null )
            {
                SceneChanger.Instance.BeforeSceneUnload += OnBeforeSceneUnload;
                SceneChanger.Instance.AfterSceneLoad += OnAfterSceneLoad;
            }
        }

        void OnDisable()
        {
            if( SceneChanger.Instance != null )
            {
                SceneChanger.Instance.BeforeSceneUnload -= OnBeforeSceneUnload;
                SceneChanger.Instance.AfterSceneLoad -= OnAfterSceneLoad;
            }
        }

        public virtual void OnBeforeSceneUnload(){}

        public virtual void OnAfterSceneLoad()
        {
            if( LoadScreenController.Instance != null )
                LoadScreenController.Fade( 0 );
        }

        public void TransitionScene( string _sceneName )
        {
            if( LoadScreenController.Instance != null )
            {
                LoadScreenController.Fade( 1, () => {
                    if( SceneChanger.Instance != null )
                        SceneChanger.ChangeScene( _sceneName );
                } );
            }
        }
    }
}