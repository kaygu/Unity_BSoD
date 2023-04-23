using UnityEngine;
using UnityEngine.SceneManagement;


namespace BSOD.Events.GameState
{
    public class GameOverListener : GameStateBaseListener
    {
        public override void OnGameStateEventRaised()
        {
            SceneManager.LoadScene(m_scenes.GameOverScene);
        }
    }
}

