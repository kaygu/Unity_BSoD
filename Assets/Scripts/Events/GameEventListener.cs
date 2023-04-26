using UnityEngine;
using UnityEngine.Events;

using BSOD.ScriptableObjects;

namespace BSOD.Events
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private GameEvent m_gameEvent;
        [SerializeField] private UnityEvent m_response;

        private void OnEnable()
        {
            m_gameEvent?.RegisterListener(this);
        }

        private void OnDisable()
        {
            m_gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            m_response?.Invoke();
        }
    }
}