using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using PersonalLibrary.pUnity.pUI;

[AddComponentMenu("PersonalLibrary/UI/Button/ThreeDButtonPointerUpDown")]
public class ThreeDButtonPointerUpDown : CustomUIButton
{
    Image targetGraphics;
    Color originalColor;

    protected override void OnDisable()
    {

    }

    protected override void OnEnable()
    {
        targetGraphics = gameObject.GetComponent<Image>();
        originalColor = targetGraphics.color;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = ogLocalScale;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = ogLocalScale * 0.85f;
        targetGraphics.color = Color.cyan;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        targetGraphics.color = originalColor;
    }
}

#if UNITY_EDITOR
namespace PersonalLibrary.pUnity.pEditor
{
    using UnityEditor;
    using TARGET = ThreeDButtonPointerUpDown;

    public partial class CustomUIButton_Editor
    {
        // UIButton_2 - ThreeDButtonPointerUpDown
        [MenuItem(CUSTOM_UIBUTTON_PATH + UIBUTTON_2, false, 20)]
        static void CreateCustomButton_2(MenuCommand menuCmd)
        {
            CreateCustomUIButton<TARGET>(menuCmd);
        }
    }
}
#endif
