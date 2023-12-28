
using UnityEngine;
[CreateAssetMenu(fileName = "New hp", menuName = "GameData/Items/Potion/Hp")]

public class hpSO : potionSO
{
    [Space]
    [Header("Uses")]
    public int hP;
    public override void Update()
    {
        base.Update();
        this.PotionType = PotionType.hp;
        this.Description = "Dùng để tăng lượng hp cho bản thân";
        this.HP = hP;
    }
    
}
