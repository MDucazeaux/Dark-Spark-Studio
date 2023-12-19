using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float _time;

    private void Awake()
    {
        Destroy(gameObject, _time);
    }
}
