using UnityEngine;

public abstract class Throwable : MonoBehaviour
{
    private Transform _transform;

    protected float _damage = 1;
    [SerializeField] protected float _speed = 1;
    private int _maxDistance = 40;
    private Vector3 _direction = Vector3.zero;
    private Vector3 _startPosition = Vector3.zero;

    private bool _IsGoingToTarget = false;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (!_IsGoingToTarget)
        {
            if (Vector3.Distance(_startPosition, _transform.position) > _maxDistance)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }

        _transform.position += _direction * _speed * Time.deltaTime;
    }

    public abstract void SetValues();

    public void SetDamage(float damage) { _damage = damage; }

    public void SetSpeed(float speed) { _speed = speed; }

    public void SetDirection(Vector3 direction) { _direction = direction; }
    
    public void SetDirection(GameObject target) { _IsGoingToTarget = true; _direction = (target.transform.position - _transform.position).normalized; }

    public void SetStartPosition(Vector3 startPosition) { _startPosition = startPosition; }

    public void SetMaxDistance(int maxDistance) { _maxDistance = maxDistance; }
}
