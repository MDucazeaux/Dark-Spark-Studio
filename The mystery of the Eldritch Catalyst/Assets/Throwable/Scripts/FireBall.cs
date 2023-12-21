using System.Collections;
using UnityEngine;

public class FireBall : Throwable
{
    private bool _bisEnemySeen = false;
    private float _enemyDist;

    public override void Update()
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

        if (!_bisEnemySeen && Physics.Raycast(_transform.position, _direction,
            out RaycastHit hitInfo, Vector3.Distance(_transform.position, _startPosition + _direction * _maxDistance), 1 << LayerMask.NameToLayer("Enemy")))
        {
            _bisEnemySeen = true;
            _enemyDist = Vector3.Distance(_startPosition, hitInfo.collider.transform.position);
        }
        if(_bisEnemySeen)
        {
            float Ymult = 1 - Vector3.Distance(_startPosition, _transform.position) / _enemyDist;
            _transform.position = Vector3.Lerp(_transform.position, new Vector3(_transform.position.x, _startPosition.y * Ymult, _transform.position.z), 4f * Time.deltaTime);
        }
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
