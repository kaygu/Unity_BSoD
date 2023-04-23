using UnityEngine;
using UnityEngine.SceneManagement;

namespace BSOD.Events.GameState
{
    public class GameListener : GameStateBaseListener
    {
        public override void OnGameStateEventRaised()
        {
            SceneManager.LoadScene(m_scenes.GameScene);
        }
    }
}