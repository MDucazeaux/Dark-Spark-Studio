using System.Collections;
using UnityEngine;

public class FireBall : Throwable
{
    private void Start()
    {
        StartCoroutine(FireSounds());
    }

    private IEnumerator FireSounds()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

    public override void SetValues(Vector3 position, Vector3 direction)
    {
        _damage = 25;
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
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.FireBallExplosion, 0.85f);
        }
    }
}
