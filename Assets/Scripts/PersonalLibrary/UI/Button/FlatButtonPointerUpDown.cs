using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using PersonalLibrary.Utilities;
using PersonalLibrary.pUnity.pUI;

[AddComponentMenu("PersonalLibrary/UI/Button/FlatButtonPointerUpDown")]
public class FlatButtonPointerUpDown : CustomUIButton
{
    protected PointerEventData.InputButton intendedMouseButton = PointerEventData.InputButton.Left;

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!IsInteractable) return;

        Pressed();
        transform.localScale = ogLocalScale * 0.85f;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (!IsInteractable) return;

        Released();
        transform.localScale = ogLocalScale;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != intendedMouseButton) return;

        Clicked();
    }
}

#if UNITY_EDITOR
namespace PersonalLibrary.pUnity.pEditor
{
    using UnityEditor;
    using TARGET = FlatButtonPointerUpDown;

    public partial class CustomUIButton_Editor
    {
        // UIButton_1 - FlatButtonPointerUpDown
        [MenuItem(CUSTOM_UIBUTTON_PATH + UIBUTTON_1, false, 20)]
        static void CreateUIButton_1(MenuCommand menuCmd)
        {
            CreateCustomUIButton<TARGET>(menuCmd);
        }
    }
}
#endif