using System;
using System.Collections;
using UnityEngine;

namespace Utilities.LoadScreen
{
    [ RequireComponent( typeof( CanvasGroup ) ) ]
    public class LoadScreenController : MonoBehaviour
    {

        #region Public Properties
        public static LoadScreenController Instance;
        public float fadeDuration = 1;
        #endregion

        #region Private Properties
        private CanvasGroup canvasGroup;
        private Coroutine fadeCoroutine;
        #endregion

        void Awake()
        {
            if( Instance == null )
                Instance = this;
            else if( Instance != this )
                Destroy( gameObject );

            canvasGroup = GetComponent<CanvasGroup>();
        }

        public static void Fade( int _alpha )
        {
            Instance.DoFade( _alpha, () => {} );
        }

        public static void Fade( int _alpha, Action _onFadeFinished )
        {
            Instance.DoFade( _alpha, _onFadeFinished );
        }

        public void DoFade( int _alpha, Action _onFadeFinished )
        {
            if( fadeCoroutine != null )
                StopCoroutine( fadeCoroutine );

            fadeCoroutine = StartCoroutine( FadeLoadScreen( _alpha, _onFadeFinished ) );
        }

        private IEnumerator FadeLoadScreen( int _alpha, Action _onFadeFinished )
        {
            canvasGroup.blocksRaycasts = true;
            float fadeSpeed = Mathf.Abs( canvasGroup.alpha - _alpha ) / fadeDuration;
            while( !Mathf.Approximately( canvasGroup.alpha, _alpha ) )
            {
                canvasGroup.alpha = Mathf.MoveTowards( canvasGroup.alpha, _alpha, Time.deltaTime * fadeSpeed );
                yield return null;
            }

            canvasGroup.alpha = _alpha;
            canvasGroup.blocksRaycasts = false;
            _onFadeFinished();
        }

    }
}