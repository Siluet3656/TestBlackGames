using UnityEngine;
using UnityEngine.UI;

public class CustomScrollbar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private Button _buttonUp;
    [SerializeField] private Button _buttonDown;
    [Header("Settings")]
    [SerializeField] private float _scrollbarStep = 0.1f;

    private void OnEnable()
    {
        _buttonUp.onClick.AddListener(ScrollUp);
        _buttonDown.onClick.AddListener(ScrollDown);
    }

    private void OnDisable()
    {
        _buttonUp.onClick.RemoveListener(ScrollUp);
        _buttonDown.onClick.RemoveListener(ScrollDown);
    }

    private void ScrollUp()
    {
        float newValue = _scrollbar.value + _scrollbarStep;
        
        _scrollbar.value = Mathf.Clamp(newValue, 0f, 1f);
    }

    private void ScrollDown()
    {
        float newValue = _scrollbar.value - _scrollbarStep;
        
        _scrollbar.value = Mathf.Clamp(newValue, 0f, 1f);
    }
}
