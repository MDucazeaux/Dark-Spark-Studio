using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LightFlicker : MonoBehaviour
{
    private Light _light;

    [SerializeField] private float _maxRadiusChange = 5;
    [SerializeField] private float _time = 0.25f;
    private float _baseRadius;
    private float _goToRadius;
    private bool _breachedRadius = true;

    private void Awake()
    {
        _light = GetComponent<Light>();
        _baseRadius = _light.range;
    }

    private void Update()
    {
        if (_breachedRadius)
        {
            StartCoroutine(Flicker(Random.Range(_baseRadius - _maxRadiusChange, _baseRadius + _maxRadiusChange)));
        }
    }

    private IEnumerator Flicker(float target)
    {
        _breachedRadius = false;
        float _startingRange = _light.range;
        float _elapsedTime = 0;
        while (_elapsedTime < _time)
        {
            _light.range = Mathf.Lerp(_startingRange, target, (_elapsedTime / _time));
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _breachedRadius = true;
        yield return null;
    }
}
