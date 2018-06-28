using UnityEngine;

namespace YouStartInATavern
{
    using Framework;
    using Framework.Input;

    public class GameManager : Singleton<GameManager>
    {
        void Start()
        {
            ControllerManager.ResetAllControllers();
        }

        void Update()
        {
            
        }
    }
}