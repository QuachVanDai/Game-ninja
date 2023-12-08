
public enum EquipmentType
{
    Cloth, Pant, Glove, Shoe, Rada, Avatar
}

public class EquipmentSO : ItemSO
{
    public EquipmentType equipmentType;

    public override void Update()
    {
        base.Update();

        this.itemType = ItemType.Equipment;
    }
}
