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

        [MenuItem("MyTools/Level Tools/Rotate Tool")]
        public static void InitRotateTool()
        {
            Debug.Log("Launching Rotate Tool");

            RotateTool.InitWindow();
        }

        [MenuItem("MyTools/Level Tools/Copy Paste Transform Tool")]
        public static void InitCopyPasteTool()
        {
            Debug.Log("Launching Copy Paste Transform Tool");

            CopyPasteTransformTool.InitWindow();
        }
    }
}