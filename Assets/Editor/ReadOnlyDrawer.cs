#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

/// <summary>
/// This class contain custom drawer for ReadOnly attribute.
/// </summary>
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property,
                                            GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    /// <summary>
    /// Unity method for drawing GUI in Editor
    /// </summary>
    /// <param name="position">Position.</param>
    /// <param name="property">Property.</param>
    /// <param name="label">Label.</param>
    public override void OnGUI(Rect position,
                                SerializedProperty property,
                                GUIContent label)
    {
        var previousGUIState = GUI.enabled;                         // Saving previous GUI enabled value.
        GUI.enabled = false;                                        // Disabling edit for property.
        EditorGUI.PropertyField(position, property, label, true);   // Drawing Property.
        GUI.enabled = previousGUIState;                             // Setting old GUI enabled value.
    }
}
