using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BSOD.Enemies
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] GameObject m_enemy;
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
            Instantiate(m_enemy, new Vector3(Random.Range(-m_zoneWidth, m_zoneWidth), Random.Range(-m_zoneHeight, m_zoneHeight), 0), Quaternion.identity, this.transform);
        }
    }
}

