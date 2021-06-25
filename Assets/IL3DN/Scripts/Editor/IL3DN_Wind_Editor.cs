namespace IL3DN
{
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(IL3DN_Wind))]
    public class IL3DN_Wind_Editor : Editor
    {

        Texture2D IL3DN_WindDirectionLabel;

        void OnEnable()
        {

            IL3DN_WindDirectionLabel = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/IL3DN/EditorImages/IL3DN_Label_Wind_Direction.png");

        }

        public override void OnInspectorGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(IL3DN_WindDirectionLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

        }
    }
}
