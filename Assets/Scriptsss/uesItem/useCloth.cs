using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useCloth : NCKHMonoBehaviour
{
    public ClothSO ClothSO;

    public void OnMouseDown()
    {
        PlayerItem.Instance.setCloth(ClothSO);
    }
}
