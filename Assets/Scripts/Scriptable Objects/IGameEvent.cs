using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BSOD.Events;

namespace BSOD.ScriptableObjects
{
    public interface IGameEvent
    {
        void Raise();
        void RegisterListener(IGameEventListener listener);
        void UnregisterListener(IGameEventListener listener);
        void UnregisterAll();
    }
    public interface IGameEvent<T>
    {
        void Raise(T value);
        void RegisterListener(IGameEventListener<T> listener);
        void UnregisterListener(IGameEventListener<T> listener);
        void UnregisterAll();
    }
}
