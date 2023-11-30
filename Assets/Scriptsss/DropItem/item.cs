using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class item : MonoBehaviour
{
   

    public DropItem[] dropItems;

    public void Die(Vector3 v3, Quaternion rotation)
    {
        foreach (DropItem dropItem in dropItems)
        {
            if (Random.value <= dropItem.dropRate)
            {
                DropItems(dropItem.itemPrefab, v3, rotation);
            }
        }
    }

    void DropItems(GameObject itemPrefab, Vector3 v3, Quaternion rotation)
    {
        Instantiate(itemPrefab, v3, rotation);
    }
}
