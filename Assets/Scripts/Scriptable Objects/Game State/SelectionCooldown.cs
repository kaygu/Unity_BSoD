using UnityEngine;

namespace BSOD.ScriptableObjects.GameState
{
    [CreateAssetMenu(fileName = "SelectionCooldown", menuName = "Game/Selection Cooldown")]
    public class SelectionCooldown : ScriptableObject
    {
        public float Minimum = 2f;
        public float Maximum = 15f;
        public float PerUnit = 0.09f;
    }

}
