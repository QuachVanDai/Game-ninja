public enum PotionType
{
    mp, hp, food
}
public class potionSO : ItemSO
{
    public PotionType PotionType;

    public override void Update()
    {
        base.Update();
        this.itemType = ItemType.Potion;
    }
    private int _hP;
    public int HP
    {
        get { return _hP; }
        set { _hP = value; }
    }
    private int _mP;
    public int MP
    {
        get { return _mP; }
        set { _mP = value; }
    }
}
