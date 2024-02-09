using UnityEngine;
using UnityEditor;

namespace MyTools
{
    public class EditorMenus : MonoBehaviour
    {
        [MenuItem("MyTools/Project/Project SetUp Tool")]

        public static void InitProjectSetUpTool()
        {
            Debug.Log("Launching Project SetUp Tool");

            ProjectSetUp_Window.InitWindow();
        }

    }
}