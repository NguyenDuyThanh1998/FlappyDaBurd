using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] FlatButtonPointerUpDown UIButton;
    private void OnEnable()
    {
        UIButton.ClickEvent.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        UIButton.ClickEvent.RemoveListener(OnButtonClicked);
    }

    private void Awake()
    {
        UIButton = GetComponentInChildren<FlatButtonPointerUpDown>();
    }
    public void OnButtonClicked()
    {
        Debug.Log("UIButton clicked");
    }
}
