using UnityEngine;
using UnityEngine.Events;

using BSOD.ScriptableObjects.Event;
using BSOD.ScriptableObjects;

namespace BSOD.Events
{
    public abstract class BaseGameEventListener : MonoBehaviour, IGameEventListener
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

    //
    // Unity Events cant get passed Types
    //

    //public abstract class BaseGameEventListener<T, TEvent> : MonoBehaviour, IGameEventListener<T>
    //    where TEvent : GameEventBase<T>
    //{
    //    [SerializeField] private TEvent m_gameEvent;
    //    [SerializeField] private UnityEvent m_response;

    //    private void OnEnable()
    //    {
    //        m_gameEvent?.RegisterListener(this);
    //    }

    //    private void OnDisable()
    //    {
    //        m_gameEvent.UnregisterListener(this);
    //    }

    //    public void OnEventRaised(T value)
    //    {
    //        m_response?.Invoke(value);
    //    }
    //}
}