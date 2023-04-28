using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BSOD.ScriptableObjects.GameState
{
    [CreateAssetMenu(fileName = "GameScenes", menuName = "Game/Scenes")]
    public class GameScenes : ScriptableObject
    {
        public int StartScene = 0;
        public int GameScene = 1;
        public int GameOverScene = 2;
    }
}

