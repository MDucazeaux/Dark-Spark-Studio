using UnityEngine;

public class FireBall : Throwable
{
    public override void SetValues()
    {
        _damage = 25;
        _speed = 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {

        }
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
