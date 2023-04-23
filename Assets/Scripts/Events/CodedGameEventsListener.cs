using System;
using UnityEngine;

using BSOD.ScriptableObjects.GameState;

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
}

