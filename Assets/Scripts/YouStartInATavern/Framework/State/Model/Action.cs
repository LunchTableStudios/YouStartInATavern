namespace YouStartInATavern.Framework.State
{
    using UnityEngine;

    public abstract class Action : ScriptableObject
    {
        public abstract void Call( PluggableStateMachine _machine );
    }
}