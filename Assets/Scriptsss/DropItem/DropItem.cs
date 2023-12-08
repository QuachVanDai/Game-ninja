
using UnityEngine;

[System.Serializable]
public class DropItem
{
    public GameObject itemPrefab;
    [Range(0.0f, 1.0f)]
    public float dropRate;
}