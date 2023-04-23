using UnityEngine;

using BSOD.ScriptableObjects.GameState;

namespace BSOD.Events.GameState
{
    public abstract class GameStateBaseListener: MonoBehaviour
    {
        [SerializeField] private CodedGameEventsListener m_event;
        [SerializeField] protected GameScenes m_scenes;

        private void OnEnable()
        {
            m_event?.OnEnable(OnGameStateEventRaised);
        }

        private void OnDisable()
        {
            m_event?.OnDisable();
        }

        public abstract void OnGameStateEventRaised();
    }
}

