using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
