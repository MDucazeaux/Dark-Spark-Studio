using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New Item")]
public class ItemData : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public ItemType itemType;
    public int healing;
    public int stamina;
}

public enum ItemType
{
    Equipment,
    Consumable,
}