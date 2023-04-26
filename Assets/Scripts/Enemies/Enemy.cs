using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BSOD.ScriptableObjects.Enemies;

namespace BSOD.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyRuntimeSet m_enemySet;
        [SerializeField] private EnemyRuntimeSet m_toDestroySet;
        private void OnEnable()
        {
            m_enemySet.Add(this.transform);
        }

        private void OnDisable()
        {
            m_toDestroySet.Remove(this.transform);
            m_enemySet.Remove(this.transform);
        }
    }
}

