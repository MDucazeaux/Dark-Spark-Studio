using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField]
    private List<LootTableData> _dropTables = new List<LootTableData>();

    private List<ItemData> _dropList;

    [System.Serializable]
    private struct LootTableData
    {
        [SerializeField]
        public string EnemyType;
        [SerializeField]
        public List<ItemDropData> ItemsToLoot;
        [SerializeField]
        public List<ItemDropData> LootTable;
        [SerializeField]
        public int ChestQuantity;
    }

    [System.Serializable]
    private struct ItemDropData
    {
        [SerializeField]
        public ItemData itemCanDropped;
        [SerializeField]
        public int[] dropPercentages;
        [SerializeField]
        public int maxQuantity;
    }

    public void DropCalculation(string enemy)
    {
        _dropList.Clear();

        for (int i = 0; i < _dropTables.Count; i++)
        {
            if (_dropTables[i].EnemyType == enemy)
            {
                for (int j = 0; j < _dropTables[i].LootTable.Count; j++)
                {
                    for (int k = 0; k < _dropTables[i].LootTable[j].maxQuantity; k++)
                    {
                        if (_dropTables[i].LootTable[j].dropPercentages[k] >= UnityEngine.Random.Range(0, 100))
                        {
                            _dropList.Add(_dropTables[i].LootTable[j].itemCanDropped);
                        }
                    }
                }
            }
        }
    }

    public void DropChestCalculation(string enemy)
    {
        _dropList.Clear();

        for (int i = 0; i < _dropTables.Count; i++)
        {
            if (_dropTables[i].EnemyType == enemy)
            {
                for (int j = 0; j < _dropTables[i].ItemsToLoot.Count; j++)
                {
                    for (int k = 0; k < _dropTables[i].ItemsToLoot[j].maxQuantity; k++)
                    {
                        _dropList.Add(_dropTables[i].ItemsToLoot[j].itemCanDropped);
                    }
                }
                while(_dropList.Count < _dropTables[i].ChestQuantity)
                {
                    int dropPercentage = UnityEngine.Random.Range(0, 100);
                    for (int j = 0; j < _dropTables[i].LootTable.Count; j++)
                    {
                        dropPercentage -= _dropTables[i].LootTable[j].dropPercentages[0];
                        if (dropPercentage <= 0)
                        {
                            _dropList.Add(_dropTables[i].LootTable[j].itemCanDropped);
                        }
                    }
                }
            }
        }
    }

    public void DropItems(Transform transform, string enemy)
    {
        DropCalculation(enemy);
        for (int i = 0; i < _dropList.Count; i++)
        {
            GameObject instantiatedItem = Instantiate(_dropList[i].GetPrefab());
            instantiatedItem.transform.position = transform.position;
        }
    }

    public void DropItemsInChests(Transform transform, string chest)
    {
        DropChestCalculation(chest);
        for (int i = 0; i < _dropList.Count; i++)
        {
            GameObject instantiatedItem = Instantiate(_dropList[i].GetPrefab());
            instantiatedItem.transform.position = transform.position;
        }
    }
}
