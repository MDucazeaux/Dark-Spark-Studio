using UnityEngine;

public class ProjectSpell : MonoBehaviour
{
    private Vector3 _startingPos;
    private Transform _transform;
    [SerializeField] private float _travelDistance;
    [SerializeField] private float _travelSpeed;

    private void Awake()
    {
        _transform = transform;
        _transform.position = new Vector3(_transform.position.x, 5, _transform.position.z);
    }

    private void Start()
    {
        _startingPos = transform.position;
    }

    void Update()
    {
        _transform.position = Vector3.Lerp(_transform.position, _startingPos + _transform.forward * _travelDistance, _travelSpeed * Time.deltaTime);
    }
}
