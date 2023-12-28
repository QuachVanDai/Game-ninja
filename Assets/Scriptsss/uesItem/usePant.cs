using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usePant : NCKHMonoBehaviour
{
    public PantSO PantSO;

    public void OnMouseDown()
    {
        PlayerItem.Instance.setPant(PantSO);
    }
}
