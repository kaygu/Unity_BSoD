using UnityEngine;
using UnityEditor;

using BSOD.ScriptableObjects;

namespace BSOD.UnityEditor
{
    [CustomEditor(typeof(GameEventBase))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameEventBase gameEvent = (GameEventBase)target;

            if (GUILayout.Button("Raise()", GUILayout.Height(75)))
            {
                gameEvent.Raise();
            }
        }
    }
}
