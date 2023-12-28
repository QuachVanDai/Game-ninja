
using UnityEngine;

public enum ItemType
{
    None, Potion, Equipment, Other
}

public class ItemSO: ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite icon;
    public int level;
    public bool isStackable = true;
    public string Description;

    public void OnEnable()
    {
        this.Update();
    }

    public virtual void Update()
    {
           
    }
    public void show()
    {

    }
    public virtual ItemSO getItemSO() { return this; }
    private int _xu;
    public int XU
    {
        get { return _xu; }
        set { _xu = value; }
    }
}
