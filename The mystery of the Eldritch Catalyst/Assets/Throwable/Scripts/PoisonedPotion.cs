using UnityEngine;

public class PoisonedPotion : Throwable
{
    public override void SetValues(Vector3 position, Vector3 direction)
    {
        _damage = 5;
        _speed = 5;
        _direction = direction;
        _transform.position = position;
        _startPosition = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Explode(false);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {

            other.GetComponentInParent<Enemy>().TakeDamage(_damage);
            Explode(true);
        }
    }

    private void Explode(bool touchedEnemy = false)
    {
        Destroy(gameObject);
        if (_touchParticle)
        {
            Instantiate(_touchParticle, transform.position, transform.rotation);
        }
    }
}
