using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace MyTools
{
    public class RotateTool : EditorWindow
    {
        #region Variables
        int currentSelectionCount = 0;
        float desiredRotationX = 0f;
        float desiredRotationY = 0f;
        float desiredRotationZ = 0f;
        #endregion

        #region Main Methods
        public static void InitWindow()
        {
            var editorWin = GetWindow<RotateTool>("RotateTool");
            editorWin.Show();
        }

        private void OnGUI()
        {
            GetSelection();
            EditorGUILayout.BeginVertical();

            EditorGUILayout.LabelField("Selection Count:" + currentSelectionCount.ToString(), EditorStyles.boldLabel);

            EditorGUILayout.LabelField("Desired X rotation:", EditorStyles.boldLabel);
            desiredRotationX = EditorGUILayout.FloatField(desiredRotationX);
            EditorGUILayout.LabelField("Desired Y rotation:", EditorStyles.boldLabel);
            desiredRotationY = EditorGUILayout.FloatField(desiredRotationY);
            EditorGUILayout.LabelField("Desired Z rotation:", EditorStyles.boldLabel);
            desiredRotationZ = EditorGUILayout.FloatField(desiredRotationZ);

            if (GUILayout.Button("Apply desired Rotation", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
            {
                ApplyNewRotation();
            }

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
            Repaint();
        }
        #endregion

        #region Custom Methods
        void GetSelection()
        {
            currentSelectionCount = 0;
            currentSelectionCount = Selection.gameObjects.Length;
        }

        void ApplyNewRotation()
        {
            //Check for Selection count
            if (currentSelectionCount == 0)
            {
                CustomDialog("At least one Object must be selected to be rotated!");
                return;
            }
            //Check for desired rotation
            if (desiredRotationX == 0 && desiredRotationY == 0 && desiredRotationZ == 0)
            {
                CustomDialog("At least one desired rotation must be different to 0!");
                return;
            }

            GameObject[] selectedObjects = Selection.gameObjects;
            for (int i = 0; i < selectedObjects.Length; i++)
            {
                selectedObjects[i].transform.Rotate(new Vector3(desiredRotationX, desiredRotationY, desiredRotationZ));      
            }
        }

        void CustomDialog(string aMessage)
        {
            EditorUtility.DisplayDialog("Objects Replace Warning", aMessage, "Okay");
        }
        #endregion
    }
}
