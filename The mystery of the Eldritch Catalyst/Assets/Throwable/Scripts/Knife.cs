using UnityEngine;

public class Knife : Throwable
{
    [SerializeField] private GameObject _dustParticle;
    [SerializeField] private AnimationCurve _curve;

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

        float newMaxDist = _maxDistance;
        if (Physics.Raycast(_transform.position, _direction,
            out RaycastHit hitInfo, _maxDistance - Vector3.Distance(_startPosition, _transform.position), 1 << LayerMask.NameToLayer("Enemy")))
        {
            if (hitInfo.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                newMaxDist = Vector3.Distance(hitInfo.collider.transform.position, _startPosition);
            }
            else if (hitInfo.collider.transform.parent.TryGetComponent<Enemy>(out Enemy enemy2)) 
            {
                newMaxDist = Vector3.Distance(hitInfo.collider.transform.parent.position, _startPosition);
            }
        }
        float posY = (Vector3.Distance(_startPosition, _transform.position) / newMaxDist);
        posY = _curve.Evaluate(posY);
        _transform.position = new Vector3(_transform.position.x, _startPosition.y * posY, _transform.position.z);
        if (posY <= 0)
        {
            Explode(false);
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.KnifeHitWall);
        }
    }

    public override void SetValues(Vector3 position, Vector3 direction)
    {
        _damage = 15;
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
        if (_touchParticle && touchedEnemy)
        {
            Instantiate(_touchParticle, transform.position, transform.rotation);
        }
        else if (_dustParticle && !touchedEnemy)
        {
            Instantiate(_dustParticle, transform.position, transform.rotation);
        }
    }
}
