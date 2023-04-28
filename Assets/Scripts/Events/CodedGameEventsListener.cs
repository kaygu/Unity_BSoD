using System;
using UnityEngine;

using BSOD.ScriptableObjects.Event;
using BSOD.ScriptableObjects;

namespace BSOD.Events
{
    [Serializable]
    public class CodedGameEventsListener : IGameEventListener
    {
        [SerializeField] private GameEvent m_gameEvent;
        private Action m_response;

        public void OnEnable(Action response)
        {
            m_gameEvent?.RegisterListener(this);
            m_response = response;
        }

        public void OnDisable()
        {
            m_gameEvent?.UnregisterListener(this);
            m_response = null;
        }
        public void OnEventRaised()
        {
            m_response?.Invoke();
        }
    }

    [Serializable]
    public class CodedGameEventsListener<T, TEvent> : IGameEventListener<T>
        where TEvent : GameEventBase<T>
    {
        [SerializeField] private TEvent m_gameEvent;
        private Action<T> m_response;

        public void OnEnable(Action<T> response)
        {
            m_gameEvent?.RegisterListener(this);
            m_response = response;
        }

        public void OnDisable()
        {
            m_gameEvent?.UnregisterListener(this);
            m_response = null;
        }
        public void OnEventRaised(T value)
        {
            m_response?.Invoke(value);
        }
    }
}

