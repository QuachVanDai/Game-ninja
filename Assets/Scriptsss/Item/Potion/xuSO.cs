using UnityEngine;
[CreateAssetMenu(fileName = "New xu", menuName = "GameData/Items/Potion/Xu")]
public class xuSO : potionSO
{
    [Space]
    [Header("Uses")]
    public int xu;
    public override void Update()
    {
        base.Update();

        this.PotionType = PotionType.hp;
        this.Description = "Dùng xu để mua các vật phẩm";

        this.XU = xu;
    }
}
