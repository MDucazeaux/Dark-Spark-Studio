using UnityEngine;

public class PoisonedPotion : Throwable
{
    public override void SetValues()
    {
        _damage = 5;
        _speed = 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        /*if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.
        }*/
    }
}
