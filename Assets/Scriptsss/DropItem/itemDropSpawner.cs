using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDropSpawner : Spawner
{
    private static itemDropSpawner instance;
    public static itemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (itemDropSpawner.instance != null) Debug.LogError("Only 1 itemDropSpawner allow to exist");
        itemDropSpawner.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        int index = Random.Range(0, dropList.Count);
        Transform itemDrop = this.spawn("hp", pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
}
