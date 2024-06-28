using UnityEditor;
using UnityEngine;

namespace Editor.PlayerPrefs
{
    public class RemovePlayerPrefs : EditorWindow
    {
        [MenuItem("Tools/Player Prefs Remove")]
        public static void ShowWindow()
        {
            GetWindow<RemovePlayerPrefs>("Player Prefs remove");
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Reset PlayerPrefs"))
            {
                UnityEngine.PlayerPrefs.DeleteAll();
                Debug.Log("PlayerPrefs were remove.");
            }
        }
    }
}