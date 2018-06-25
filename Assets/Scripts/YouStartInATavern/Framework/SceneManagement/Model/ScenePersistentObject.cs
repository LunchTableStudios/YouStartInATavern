namespace YouStartInATavern.Framework.SceneManagement
{
    using UnityEngine;

    public class ScenePersistentObject : MonoBehaviour
    {
        [ Tooltip( "Scenes that this object will be moved to on Scene change. Will automatically move if empty." ) ]
        public string[] scenes;
    }
}