using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyTools
{
    public class ProjectSetUp_Window : EditorWindow
    {
        #region Variables
        static ProjectSetUp_Window win;
        #endregion

        #region Main Methods
        public static void InitWindow()
        {
            win = EditorWindow.GetWindow<ProjectSetUp_Window>("Project SetUp");
            win.Show();
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("Project SetUp");
        }

        #endregion
    }

}

