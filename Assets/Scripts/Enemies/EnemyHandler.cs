using UnityEngine;

using BSOD.ScriptableObjects.Enemies;

namespace BSOD.Enemies
{
    public class EnemyHandler : MonoBehaviour
    {
        [SerializeField] private GameObject m_enemy;
        [SerializeField] private EnemyRuntimeSet m_enemySet;
        [SerializeField] private EnemyRuntimeSet m_toDestroySet;
        private int m_zoneWidth = 10;
        private int m_zoneHeight = 10;

        private float m_spawnDelay = 2f;
        private float m_timePassed = 0;

        private void Start()
        {

        }

        private void Update()
        {
            if (m_timePassed >= m_spawnDelay)
            {
                Spawn();
                m_timePassed = 0;
            }
            m_timePassed += Time.deltaTime;
        }

        private void Spawn()
        {
            // Check if Position is not already taken by other enemy
            Instantiate(m_enemy, new Vector3(Random.Range(-m_zoneWidth, m_zoneWidth), Random.Range(-m_zoneHeight, m_zoneHeight), 0), Quaternion.identity, this.transform);
        }

        public void DestroyEnemies()
        {
            for (int i = m_toDestroySet.Items.Count - 1; i >= 0; i--)
            {
                Transform enemy = m_toDestroySet.Items[i];
                Destroy(enemy.gameObject);
            }
        }
    }
}

