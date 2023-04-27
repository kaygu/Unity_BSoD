using System.Collections.Generic;
using UnityEngine;

using BSOD.Events;

namespace BSOD.ScriptableObjects
{
    public abstract class GameEventBase : ScriptableObject, IGameEvent
    {
        private List<IGameEventListener> m_eventListeners = new List<IGameEventListener>();

        public void Raise()
        {
            for (int i = m_eventListeners.Count - 1; i >= 0; i--)
            {
                m_eventListeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (!m_eventListeners.Contains(listener))
            {
                m_eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            if (m_eventListeners.Contains(listener))
            {
                m_eventListeners.Remove(listener);
            }

        }

        public void UnregisterAll()
        {
            m_eventListeners.RemoveRange(0, m_eventListeners.Count);
        }
    }

    public abstract class GameEventBase<T> : ScriptableObject, IGameEvent<T>
    {
        private List<IGameEventListener<T>> m_eventListeners = new List<IGameEventListener<T>>();

        public void Raise(T value)
        {
            for (int i = m_eventListeners.Count - 1; i >= 0; i--)
            {
                m_eventListeners[i].OnEventRaised(value);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!m_eventListeners.Contains(listener))
            {
                m_eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (m_eventListeners.Contains(listener))
            {
                m_eventListeners.Remove(listener);
            }
        }
        public void UnregisterAll()
        {
            m_eventListeners.RemoveRange(0, m_eventListeners.Count);
        }
    }
}

