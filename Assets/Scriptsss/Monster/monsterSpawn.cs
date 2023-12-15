
using Unity.VisualScripting;
using UnityEngine;

public class monsterSpawn : NCKHMonoBehaviour
{
    private Transform _tranform;
    [SerializeField]
    private monster Monster;
    [SerializeField]
    private float SpawnTime;
    public  GameObject clonedMonster;
    [SerializeField] protected Transform monsterName;

    void Start()
    {
        clonedMonster = GameObject.Find("clonedMonster");
        if (_tranform != null) return;
        Monster = Monster.GetMonster();
        if (Monster == null) return;
        _tranform = lstMonster.Instance.spawn(monsterName.gameObject.name, transform.position, Quaternion.identity);
        _tranform.parent = clonedMonster.transform;
        _tranform.gameObject.SetActive(true);

    }
    private void Update()
    {
        if (_tranform != null) return;
        InvokeRepeating(nameof(spownMonster), SpawnTime, 1);
    }
    private void spownMonster()
    {
        Monster = Monster.GetMonster();
        _tranform = lstMonster.Instance.spawn(monsterName.gameObject.name, transform.position, Quaternion.identity);
        _tranform.gameObject.SetActive(true);
        _tranform.parent = clonedMonster.transform;
        CancelInvoke(nameof(spownMonster));
    }
}
