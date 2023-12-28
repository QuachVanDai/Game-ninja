using UnityEngine;
[CreateAssetMenu(fileName = "New food", menuName = "GameData/Items/Potion/Food")]

public class foodSO : potionSO
{
    [Space]
    [Header("Uses")]
    public int hP;
    public int mP;
    public override void Update()
    {
        base.Update();

        this.PotionType = PotionType.food;
        this.Description = "Dùng để tăng lượng hp và mp cho bản thân";

        this.HP = hP;
        this.MP =mP;
    }
}
