
using UnityEngine;

[CreateAssetMenu(fileName = "New Avatar", menuName = "GameData/Items/Equipment/Avatar")]
public class AvatarSO : EquipmentSO
{
    [Space]
    [Header("Animation")]
    public Sprite[] headIdle;
    public Sprite[] headRun;
    public Sprite[] headAttack;
    public Sprite[] headDown;
    public override void Update()
    {
        base.Update();

        this.equipmentType = EquipmentType.Avatar;
        this.Description = "Dùng để thay đổi khuôn mặt";

        this.SetSpriteIdle(headIdle);
        this.SetSpriteRun(headRun);
        this.SetSpriteAttack(headAttack);
        this.SetSpriteDown(headDown);
    }
}
