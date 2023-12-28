using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class slotClass 
{
    [SerializeField] private ItemSO _item;
    [SerializeField]  private int _quantity;

    public slotClass()
    {
        _item = null;
        _quantity = 0;
    }
    public slotClass(slotClass slot)
    {
        this._item = slot.getItemSO();
        this._quantity = slot.getQuantity();
    }
    public slotClass (ItemSO item,int quantity)
    {
        this._item = item;
        this._quantity = quantity;
    }
    public ItemSO getItemSO() { return _item; }
    public int getQuantity() {  return _quantity; }
    public void addQuantity(int quantity) { _quantity += quantity; }
    public void SubQuantity(int quantity) { _quantity -= quantity; }
    public void addItemSO(ItemSO item, int quantity) { _item = item; _quantity = quantity; }
    public void Clear() { _item = null; _quantity = 0; }
}
