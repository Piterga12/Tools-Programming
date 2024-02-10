using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MyTools
{
    public class ObjectsReplace_tool : EditorWindow
    {
        #region Variables
        int currentSelectionCount = 0;
        GameObject wantedObject;
        #endregion

        #region Main Methods
        public static void InitWindow()
        {
            var editorWin = GetWindow<ObjectsReplace_tool>("ReplaceObjects");
            editorWin.Show();
        }

        private void OnGUI()
        {
            GetSelection();
            EditorGUILayout.BeginVertical();

            EditorGUILayout.LabelField("Selection Count:" + currentSelectionCount.ToString(), EditorStyles.boldLabel);

            wantedObject = (GameObject)EditorGUILayout.ObjectField("Replace Object:", wantedObject, typeof(GameObject), true);
            if(GUILayout.Button("Replace Selected Objects", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
            {
                ReplaceSelectedObjects();
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

        void ReplaceSelectedObjects()
        {
            //Check for Selection count
            if(currentSelectionCount == 0)
            {
                CustomDialog("At least one Object must be selected to be replaced!");
                return;
            }
            //Check for replace Object
            if(!wantedObject)
            {
                CustomDialog("The Replace Object is empty! Please assign one");
                return;
            }

            //Replace Objects
            GameObject[] selectedObjects = Selection.gameObjects;
            for(int i = 0; i<selectedObjects.Length; i++)
            {
                Transform selectTransform = selectedObjects[i].transform;
                GameObject newObject = Instantiate(wantedObject, selectTransform.position, selectTransform.rotation);
                newObject.transform.localScale = selectTransform.localScale;

                DestroyImmediate(selectedObjects[i]);
            }
        }

        void CustomDialog(string aMessage)
        {
            EditorUtility.DisplayDialog("Objects Replace Warning", aMessage, "Okay");
        }
        #endregion
    }
}
