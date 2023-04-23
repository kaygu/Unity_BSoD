using UnityEngine;
using UnityEditor;

using BSOD.ScriptableObjects.GameState;

namespace BSOD.UnityEditor
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameEvent myGameEvent = (GameEvent)target;

            if (GUILayout.Button("Raise()", GUILayout.Height(75)))
            {
                myGameEvent.Raise();
            }
        }
    }
}
