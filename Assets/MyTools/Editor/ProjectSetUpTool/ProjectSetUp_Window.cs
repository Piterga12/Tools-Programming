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

            //Create Root Folder
            string assetPath = Application.dataPath;
            string rootPath = assetPath + "/" + gameName;

            DirectoryInfo rootInfo = Directory.CreateDirectory(rootPath);

            //Create sub Directories
            if (!rootInfo.Exists)
            {
                return;
            }
            CreateSubFolders(rootPath);

            AssetDatabase.Refresh();
            CloseWindow();
        }

        void CreateSubFolders(string rootPath)
        {
            DirectoryInfo rootInfo = null;
            List<string> folderNames = new List<string>();

            //ART FOLDERS
            rootInfo = Directory.CreateDirectory(rootPath + "/Art");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Animation");
                folderNames.Add("Objects");
                folderNames.Add("Materials");
                folderNames.Add("Prefabs");

                CreateFolders(rootPath + "/Art", folderNames);
            }

            //CODE FOLDERS
            rootInfo = Directory.CreateDirectory(rootPath + "/Code");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Editor");
                folderNames.Add("Scripts");
                folderNames.Add("Shaders");

                CreateFolders(rootPath + "/Code", folderNames);
            }

            //RESOURCE FOLDERS
            rootInfo = Directory.CreateDirectory(rootPath + "/Resources");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Characters");
                folderNames.Add("Managers");
                folderNames.Add("Props");
                folderNames.Add("UI");

                CreateFolders(rootPath + "/Resources", folderNames);
            }

            //PREFABS FOLDERS
            rootInfo = Directory.CreateDirectory(rootPath + "/Prefabs");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Characters");
                folderNames.Add("Props");
                folderNames.Add("UI");

                CreateFolders(rootPath + "/Prefabs", folderNames);
            }
        }

        void CreateFolders(string aPath, List<string> folders)
        {
            foreach(string folder in folders)
            {
                Directory.CreateDirectory(aPath + "/" + folder);
            }

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

