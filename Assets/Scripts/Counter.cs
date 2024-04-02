using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _magnificationValue;

    private float _currentValue = 0;
    private bool _isEnabled = false;
    private Coroutine  _coroutine;

    public event Action Changed;

    public float CurrentValue => _currentValue;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

        if (_isEnabled)
            TurnOff();
        else
            TurnOn();
    }

    private void TurnOn()
    {
        _isEnabled = true;
        _coroutine = StartCoroutine(IncreaseValue());
    }

    private void TurnOff()
    {
        _isEnabled = false;
        StopCoroutine(_coroutine);
    }
    
    private IEnumerator IncreaseValue()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            yield return wait;
            _currentValue += _magnificationValue;
            Changed?.Invoke();
        }
    }
}