using UnityEngine;

using BSOD.ScriptableObjects.Event;
using BSOD.Enemies;

namespace BSOD.Events.Player
{
    public class SelectedEventHandler : MonoBehaviour
    {
        [SerializeField] private CodedGameEventsListener<float, FloatGameEvent> m_event;
        [SerializeField] private EnemyHandler m_enemyHandler;

        private void OnEnable()
        {
            m_event?.OnEnable(OnSelectedEventRaised);
        }

        private void OnDisable()
        {
            m_event?.OnDisable();
        }

        public void OnSelectedEventRaised(float v)
        {
            Debug.Log("Selected: " +v);
            // Set time to next Selection here ? 
            m_enemyHandler.DestroyEnemies();
        }
    }
}
