using UnityEngine;
using UnityEditor;

namespace MyTools
{
    public class EditorMenus : MonoBehaviour
    {
        [MenuItem("MyTools/Project Tools/Project SetUp Tool")]
        public static void InitProjectSetUpTool()
        {
            Debug.Log("Launching Project SetUp Tool");

            ProjectSetUp_Window.InitWindow();
        }
        
        [MenuItem("MyTools/Level Tools/Objects Replace Tool")]
        public static void InitObjectsReplaceTool()
        {
            Debug.Log("Launching Objects Replace Tool");

            ObjectsReplace_tool.InitWindow();
        }

    }
}