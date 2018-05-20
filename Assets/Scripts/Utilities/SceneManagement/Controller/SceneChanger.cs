using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities.SceneManagement
{
    public class SceneChanger : MonoBehaviour
    {
        public static SceneChanger Instance { get; private set; }

        #region Public Properties
        public string initialScene;
        public event Action BeforeSceneUnload;
        public event Action AfterSceneLoad;
        #endregion

        #region Private Properties
        private bool isChanging = false;
        private GameObject[] persistentObjects;
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
            if( initialScene != "" )
                DoChangeScene( initialScene );
        }

        public static void ChangeScene( string _sceneName )
        {
            Instance.DoChangeScene( _sceneName );
        }

        public void DoChangeScene( string _sceneName )
        {
            if( !isChanging )
                StartCoroutine( LoadSceneAsync( _sceneName ) );
        } 

        public IEnumerator LoadSceneAsync( string _sceneName )
        {
            isChanging = true;

            if( BeforeSceneUnload != null )
                BeforeSceneUnload();

            yield return SceneManager.LoadSceneAsync( _sceneName, LoadSceneMode.Additive );
            Scene newlyLoadedScene = SceneManager.GetSceneAt( SceneManager.sceneCount - 1 );

            persistentObjects = GetPersistentObjects( _sceneName );

            for( int i = 0; i < persistentObjects.Length; i++ )
                SceneManager.MoveGameObjectToScene( persistentObjects[i], newlyLoadedScene );

            SceneManager.MoveGameObjectToScene( gameObject, newlyLoadedScene );

            SceneManager.UnloadSceneAsync( SceneManager.GetActiveScene().buildIndex );

            SceneManager.SetActiveScene( newlyLoadedScene );

            if( AfterSceneLoad != null )
                AfterSceneLoad();

            isChanging = false;
        }

        private GameObject[] GetPersistentObjects( string _nextSceneName )
        {
            ScenePersistentObject[] foundObjects = FindObjectsOfType<ScenePersistentObject>();
            List<GameObject> returnObjects = new List<GameObject>();
            for( int i = 0; i < foundObjects.Length; i++ )
            {
                if( Array.IndexOf( foundObjects[i].scenes, _nextSceneName ) != -1 || foundObjects[i].scenes.Length == 0 )
                    returnObjects.Add( foundObjects[i].gameObject );
            }

            return returnObjects.ToArray();
        }
    }
}
