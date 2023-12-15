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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            
            other.GetComponentInParent<Enemy>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
