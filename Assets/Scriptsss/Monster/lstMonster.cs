

public class lstMonster : Spawner
{
    private static lstMonster instance;

    public static string monsterName;
    protected int index=0;
    public static lstMonster Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake(); 
        lstMonster.instance = this;
    }

}
