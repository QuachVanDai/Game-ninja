using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform contentCanvas;

    [SerializeField] private InventorySlot itemSlotPrefabs;
    private readonly List<InventorySlot> slots = new();
    public const int DEFAULT_CAPACITY = 30;
    public int Capacity => slots.Count;

    private void Awake()
    {
        ChangeCapacity(DEFAULT_CAPACITY);
    }
    private void ChangeCapacity(int newCapacity)
    {
        if (newCapacity < 0)
            return;

        while (slots.Count < newCapacity)
        {
            var newSlot = Instantiate(itemSlotPrefabs, contentCanvas);
           // newSlot.PushItem(null);
            slots.Add(newSlot);
        }

        while (slots.Count > newCapacity)
        {
            int lastIndex = slots.Count - 1;
            var lastSLot = slots[lastIndex];
            slots.RemoveAt(lastIndex);
            Destroy(lastSLot.gameObject);
        }
    }
  
}
