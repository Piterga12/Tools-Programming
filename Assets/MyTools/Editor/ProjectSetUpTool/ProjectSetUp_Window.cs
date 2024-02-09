using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace MyTools
{
    public class ProjectSetUp_Window : EditorWindow
    {
        #region Variables
        static ProjectSetUp_Window win;

        private string gameName = "Game";
        #endregion

        #region Main Methods
        public static void InitWindow()
        {
            win = EditorWindow.GetWindow<ProjectSetUp_Window>("Project SetUp");
            win.Show();
        }

        void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
//            EditorGUILayout.LabelField("Project SetUp");
            gameName = EditorGUILayout.TextField("Game Name: ", gameName);
            EditorGUILayout.EndHorizontal();

            if(GUILayout.Button("Create Project Sctructure", GUILayout.Height(35), GUILayout.ExpandWidth(true)))
            {
                CreateProjectFolders();
            }

            if (win)
            {
                win.Repaint();
            }
        }

        #endregion

        #region Custom Methods
        void CreateProjectFolders()
        {
            if(string.IsNullOrEmpty(gameName))
            {
                return;
            }

            if(gameName == "Game")
            {
                if(!EditorUtility.DisplayDialog("Project SetUp Warning", "Do you really want to name your project Game?", "Yes", "No"))
                {
                    CloseWindow();
                    return;
                }
            }

            string assetPath = Application.dataPath;
            string rootPath = assetPath + "/" + gameName;

            Directory.CreateDirectory(rootPath);
            AssetDatabase.Refresh();

            CloseWindow();
        }

        void CloseWindow()
        {
            if (win)
            {
                win.Close();
            }
        }
        #endregion
    }

}

