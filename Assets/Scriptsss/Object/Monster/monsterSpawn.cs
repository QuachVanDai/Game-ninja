using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class monsterSpawn : NCKHMonobehaviour
{
    private Transform _tranform;
    [SerializeField]
    private monster Monster;
    [SerializeField]
    private float SpawnTime;
    [SerializeField] protected Transform monsterName;

    void Start()
    {
        
        if (_tranform != null) return;
        Monster = Monster.GetMonster();
        if (Monster == null) return;
        _tranform = lstMonster.Instance.spawn(monsterName.gameObject.name, transform.position, Quaternion.identity);
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
        CancelInvoke(nameof(spownMonster));
    }
}
