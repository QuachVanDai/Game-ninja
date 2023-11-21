using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class monsterSpawn : MonoBehaviour
{
    private GameObject _gameObject;
    [SerializeField]
    private monster Monster;
    [SerializeField]
    private float SpawnTime;
    
    void Start ()
    {
        if (_gameObject != null) return;
        Monster = Monster.GetMonster();
            if (Monster == null) return;
        _gameObject = Instantiate(Monster.gameObject, transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (_gameObject != null) return;
        InvokeRepeating(nameof(spownMonster), SpawnTime, 1);
    }
    private void spownMonster()
    {
        Monster = Monster.GetMonster();
        _gameObject = Instantiate(Monster.gameObject, transform.position, Quaternion.identity);
        CancelInvoke(nameof(spownMonster));
    }
}
