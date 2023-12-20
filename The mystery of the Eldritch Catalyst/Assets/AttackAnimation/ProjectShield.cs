using UnityEngine;

public class ProjectShield : MonoBehaviour
{
    private Vector3 _startingPos;
    private Transform _transform;
    [SerializeField] private float _travelDistance;
    [SerializeField] private float _travelSpeed;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _startingPos = transform.localPosition;
    }

    void Update()
    {
        _transform.localPosition = Vector3.Lerp(_transform.localPosition, new Vector3(0, 0.15f, 1) * _travelDistance, _travelSpeed * Time.deltaTime);
    }
}
