#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace PersonalLibrary.pUnity.pEditor
{
    /// <summary>
    /// Adds the ability to right-click in Unity Editor's Hierarchy tab and add CustomUIButton component as a GameObject.
    /// </summary>
    public partial class CustomUIButton_Editor
    {
        protected const string CUSTOM_UIBUTTON_PATH = "GameObject/PersonalLibrary/UI/Button/";
        protected const string UIBUTTON_1 = "FlatButtonPointerUpDown";
        protected const string UIBUTTON_2 = "ThreeDButtonPointerUpDown";

        /// <summary>
        /// Generic method to create custom button.
        /// "static" because MenuItem (and menu commands in general) requires a static method;
        /// and for those static methods to use "CreateCustomUIButton" without needing an object reference,
        /// "CreateCustomUIButton" should also be static. There are other ways to handle the issue but this is what I went for.
        /// For more info, check out: https://stackoverflow.com/a/498410
        /// </summary>
        /// <typeparam name="T">Custom UIButton Component</typeparam>
        /// <param name="menuCommand">Menu command</param>
        /// <returns>The custom button Gameobject</returns>
        protected static GameObject CreateCustomUIButton<T>(MenuCommand menuCommand) where T : Component
        {
            // Create a new game object.
            GameObject go = new GameObject("Button_" + typeof(T).Name);

            // Ensure it gets reparented if this was a context click (otherwise does nothing).
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);

            // Add Custom Button + other components if  needed.
            go.AddComponent<T>();

            // Register the creation in the undo system.
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);

            // Returns object selection.
            Selection.activeObject = go;

            return go;
        }
    }

    public partial class CustomUIPopup_Editor
    {
        // Wip
    }
}
#endif