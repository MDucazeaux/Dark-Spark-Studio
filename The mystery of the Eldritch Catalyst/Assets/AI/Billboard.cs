using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _mainCamera;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    void Start()
    {
        _mainCamera = Camera.main.transform;
    }

    void LateUpdate()
    {
        _transform.LookAt(_mainCamera);
        _transform.Rotate(0, 180, 0);
        _transform.localEulerAngles = new Vector3(0, _transform.localEulerAngles.y, 0);
    }
}
