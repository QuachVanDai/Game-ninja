
using UnityEngine;

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
    private Sprite[] spriteIdle;
    public Sprite[] GetSpriteIdle
    {
        get { return this.spriteIdle; }
    }
    public void SetSpriteIdle(Sprite[] sprite)
    {
        this.spriteIdle = sprite;
    }


    private Sprite[] spriteRun;
    public Sprite[] GetSpriteRun
    {
        get { return this.spriteRun; }
    }
    public void SetSpriteRun(Sprite[] sprite)
    {
        this.spriteRun = sprite;
    }


    private Sprite[] spriteAttack;
    public Sprite[] GetSpriteAttack
    {
        get { return this.spriteAttack; }
    }
    public void SetSpriteAttack(Sprite[] sprite)
    {
        this.spriteAttack = sprite;
    }
    private Sprite[] spriteDown;
    public Sprite[] GetSpriteDown
    {
        get { return this.spriteDown; }
    }
    public void SetSpriteDown(Sprite[] sprite)
    {
        this.spriteDown = sprite;
    }
}
