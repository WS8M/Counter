using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void OnEnable()
    {
        _counter.Changed += UpdateText;
    }

    private void OnDisable()
    {
        _counter.Changed -= UpdateText;
    }

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _counterText.text = _counter.CurrentValue.ToString();
    }
}