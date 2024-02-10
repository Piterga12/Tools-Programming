using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace MyTools
{
    public class CopyPasteTransformTool : EditorWindow
    {
        #region Variables
        int currentSelectionCount = 0;
        GameObject wantedObject;
        #endregion

        #region Main Methods
        public static void InitWindow()
        {
            var editorWin = GetWindow<CopyPasteTransformTool>("CopyPasteTransformTool");
            editorWin.Show();
        }

        private void OnGUI()
        {
            GetSelection();
            EditorGUILayout.BeginVertical();

            EditorGUILayout.LabelField("Selection Count:" + currentSelectionCount.ToString(), EditorStyles.boldLabel);

            wantedObject = (GameObject)EditorGUILayout.ObjectField("Copy Transform from Object:", wantedObject, typeof(GameObject), true);

            if (GUILayout.Button("Paste Rotation", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
            {
                PasteRotation();
            }
            if (GUILayout.Button("Paste Position", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
            {
                PastePosition();
            }
            if (GUILayout.Button("Paste Rotation & Position", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
            {
                PasteRotationPosition();
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

        void PasteRotation()
        {
            //Check Availability
            if (!CheckAvailability())
            {
                return;
            }

            GameObject[] selectedObjects = Selection.gameObjects;
            for (int i = 0; i < selectedObjects.Length; i++)
            {
                selectedObjects[i].transform.rotation = wantedObject.transform.rotation;
            }
        }

        void PastePosition()
        {
            //Check Availability
            if (!CheckAvailability())
            {
                return;
            }

            GameObject[] selectedObjects = Selection.gameObjects;
            for (int i = 0; i < selectedObjects.Length; i++)
            {
                selectedObjects[i].transform.position = wantedObject.transform.position;
            }
        }

        void PasteRotationPosition()
        {
            //Check Availability
            if (!CheckAvailability())
            {
                return;
            }

            GameObject[] selectedObjects = Selection.gameObjects;
            for (int i = 0; i < selectedObjects.Length; i++)
            {
                selectedObjects[i].transform.rotation = wantedObject.transform.rotation;
                selectedObjects[i].transform.position = wantedObject.transform.position;
            }
        }

        bool CheckAvailability()
        {
            //Check for Selection count
            if (currentSelectionCount == 0)
            {
                CustomDialog("At least one Object must be selected to be rotated!");
                return false;
            }
            //Check for Copy Transform GameObject
            if (!wantedObject)
            {
                CustomDialog("The Copy Transform from Object is empty! Please assign an Object");
                return false;
            }

            return true;
        }

        void CustomDialog(string aMessage)
        {
            EditorUtility.DisplayDialog("Objects Replace Warning", aMessage, "Okay");
        }
        #endregion
    }
}
