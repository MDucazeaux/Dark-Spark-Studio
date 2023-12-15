using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float _shakeAmount = 0.01f;
    [SerializeField] private float _shakeSpeed = 15f;
    [SerializeField] private float _shakeDuration = 0.3f;
    [SerializeField] private float _shakeDelay = 0.01f;
    [SerializeField] private Image _damageFilter;

    private bool _isShake = false;
    [SerializeField] private float _bloodDuration = 0.3f;


    private void Awake()
    {
        _transform = transform;
    }

    public void TakeDamage()
    {
        if (!_isShake)
        {
            _isShake = true;
            StartCoroutine(ShakeScreen(_shakeDuration));
            StartCoroutine(BloodFilter(_shakeDuration));
        }
    }
    private IEnumerator ShakeScreen(float shakeDuration)
    {
        
        float time = 0;

        Vector3 _oldpos = _transform.localPosition;

        while (time < shakeDuration)
        {
            _transform.localPosition = new Vector3(_oldpos.x + Mathf.PerlinNoise(_shakeSpeed * Time.time, 0) * _shakeAmount, _oldpos.y + Mathf.PerlinNoise(0, _shakeSpeed * Time.time) * _shakeAmount, _transform.localPosition.z);
            time += Time.deltaTime;
            yield return new WaitForSeconds(_shakeDelay);
            yield return null;
        }

        _transform.localPosition = _oldpos;

        _isShake = false;
    }

    private IEnumerator BloodFilter(float duration)
    {
        float time = 0;

        while (time < duration)
        {
            _damageFilter.color = Color.Lerp(_damageFilter.color, new Color(_damageFilter.color.r, _damageFilter.color.g, _damageFilter.color.b, 1), 5f * Time.deltaTime);
            yield return new WaitForSeconds(_shakeDelay);
            time += Time.deltaTime;
            yield return null;
        }

        while (time < _bloodDuration + duration)
        {
            time += Time.deltaTime;
            yield return null;
        }
        while (_damageFilter.color.a > 0.1f)
        {
            _damageFilter.color = Color.Lerp(_damageFilter.color, new Color(_damageFilter.color.r, _damageFilter.color.g, _damageFilter.color.b, 0), 5f * Time.deltaTime);
            yield return null;
        }
        _damageFilter.color = new Color(_damageFilter.color.r, _damageFilter.color.g, _damageFilter.color.b, 0);
    }
}
