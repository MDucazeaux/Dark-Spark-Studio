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
    }
}
