using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BSOD.ScriptableObjects.Player
{
    [CreateAssetMenu(fileName = "CharacterMovementStats", menuName = "Player/Character Movement")]
    public class CharacterMovement : ScriptableObject
    {
        public float Velocity = 1;
        public float DiagonalLimiter = .85f;

        // Higher = Smoother
        public float AccelerationSmoothness = 10;
        public float DecelerationSmoothness = 2;

    }

}
