using UnityEngine;

public static class ScriptableObjectExtension
{
    /// <summary>
    /// Creates and returns a clone of any given scriptable object.
    /// </summary>
    public static T Clone<T>(this T scriptableObject) where T : ScriptableObject
    {
        if (scriptableObject == null)
        {
#if UNITY_EDITOR
            Debug.LogError($"ScriptableObject was null. Returning default {typeof(T)} object.");
#endif
            return (T)ScriptableObject.CreateInstance(typeof(T));
        }

        T instance = Object.Instantiate(scriptableObject);
        instance.name = scriptableObject.name + "_Clone"; // TODO: add counter to track clone number.
        return instance;
    }
}
