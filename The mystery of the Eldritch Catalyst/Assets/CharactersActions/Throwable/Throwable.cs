using UnityEngine;

public class Throwable : MonoBehaviour
{
    private Transform _transform;

    private float _damage = 1;
    private float _speed = 1;
    private int _maxDistance = 0;
    private Vector3 _direction = Vector3.zero;
    private Vector3 _startPosition = Vector3.zero;

    private bool _toTarget = false;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (!_toTarget)
        {
            if (Vector3.Distance(_startPosition, _transform.position) > _maxDistance)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }

        _transform.position += _direction * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        /*if (collision.transform.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }*/
    }

    public void SetDamage(float damage) { _damage = damage; }

    public void SetSpeed(float speed) { _speed = speed; }

    public void SetDirection(Vector3 direction) { _direction = direction; }
    
    public void SetDirection(GameObject target) { _toTarget = true; _direction = (target.transform.position - _transform.position).normalized; }

    public void SetStartPosition(Vector3 startPosition) { _startPosition = startPosition; }

    public void SetMaxDistance(int maxDistance) { _maxDistance = maxDistance; }
}
