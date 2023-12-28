
using UnityEngine;

[CreateAssetMenu(fileName = "New Pant", menuName = "GameData/Items/Equipment/Pant")]
public class PantSO : EquipmentSO
{
    [Header("Increase HP")]
    public int HpValue;

    [Space]
    [Header("Animation")]
    public Sprite[] legIdle;
    public Sprite[] legRun;
    public Sprite[] legAttack;
    public Sprite[] legDown;
    public override void Update()
    {
        base.Update();

        this.equipmentType = EquipmentType.Pant;
        this.Description = "Giúp cơ thể tăng lượng HP và MP ";

        this.SetSpriteIdle(legIdle);
        this.SetSpriteRun(legRun);
        this.SetSpriteAttack(legAttack);
        this.SetSpriteDown(legDown);
    }
}
