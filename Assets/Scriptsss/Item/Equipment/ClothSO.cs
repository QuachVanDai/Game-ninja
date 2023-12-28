
using UnityEngine;

[CreateAssetMenu(fileName = "New Cloth", menuName = "GameData/Items/Equipment/Cloth")]
public class ClothSO : EquipmentSO
{
    [Header("Increase Armor")]
    public int armorValue;

    [Space]
    [Header("Animation")]
    public Sprite[] bodyIdle;
    public Sprite[] bodyRun;
    public Sprite[] bodyAttack;
    public Sprite[] bodyDown;
    public override void Update()
    {
        base.Update();

        this.equipmentType = EquipmentType.Cloth;
        this.Description = "Giúp giảm sát thương tấn công từ quái vật.";

        this.SetSpriteIdle(bodyIdle);
        this.SetSpriteRun(bodyRun);
        this.SetSpriteAttack(bodyAttack);
        this.SetSpriteDown(bodyDown);
    }
}
