using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;

    private Transform _transform;

    private Camera _camera;

    private void Start()
    {
        ItemsOnFloor.Instance.AddItemOnTheFloor(this);
        _camera = Camera.main;
        _transform = transform;
    }

    private void Update()
    {
        LookAtCamera();
    }

    public void LookAtCamera()
    {
        _transform.LookAt(_camera.transform);
    }

    private void OnDestroy()
    {
        ItemsOnFloor.Instance.RemoveItemOnTheFloor(this);
    }
}