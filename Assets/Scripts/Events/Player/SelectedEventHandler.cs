using UnityEngine;

using BSOD.Enemies;

namespace BSOD.Events.Player
{
    public class SelectedEventHandler : MonoBehaviour
    {
        [SerializeField] private CodedGameEventsListener m_event;
        [SerializeField] private EnemyHandler m_enemyHandler;

        private void OnEnable()
        {
            m_event?.OnEnable(OnSelectedEventRaised);
        }

        private void OnDisable()
        {
            m_event?.OnDisable();
        }

        public void OnSelectedEventRaised()
        {
            Debug.Log("Selected");
            // Set time to next Selection here ? 
            m_enemyHandler.DestroyEnemies();
        }
    }
}
