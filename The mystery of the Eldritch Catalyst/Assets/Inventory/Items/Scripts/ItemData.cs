using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New Item")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private string _description;

    [SerializeField]
    private Sprite _icon;

    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private ItemType _itemType;

    [SerializeField]
    private int _healing;

    [SerializeField]
    private int _staminaStats;

    [SerializeField]
    private float _armorStats;

    [SerializeField]
    private float _physicalStrengthStats;

    [SerializeField]
    private float _magicalStrengthStats;

    public string GetName() {  return _name; }
    public string GetDescription() {  return _description; }
    public Sprite GetIcon() {  return _icon; }
    public GameObject GetPrefab() {  return _prefab; }
    public ItemType GetItemType() {  return _itemType; }
    public int GetHealing() {  return _healing; }
    public int GetStaminaStats() {  return _staminaStats; }
    public float GetArmorStats() {  return _armorStats; }
    public float GetPhysicalStrengthStats() {  return _physicalStrengthStats; }
    public float GetMagicalStrengthStats() {  return _magicalStrengthStats; }
}

public enum ItemType
{
    Armor,
    Weapon,
    Consumable,
}