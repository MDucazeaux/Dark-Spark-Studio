using UnityEngine;

public class FireBall : Throwable
{
    public override void SetValues(Vector3 position, Vector3 direction)
    {
        _damage = 25;
        _speed = 5;
        _direction = direction;
        _transform.position = position;
        _startPosition = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
