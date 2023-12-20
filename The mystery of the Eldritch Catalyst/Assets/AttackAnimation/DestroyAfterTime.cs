using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    
    [SerializeField] private float _time;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        Destroy(gameObject, _time);
    }

    private void Update()
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color -= Color.black * Time.deltaTime / _time;
        }
    }

    public void SetTime(float time)
    {
        _time = time;
    } 
}
