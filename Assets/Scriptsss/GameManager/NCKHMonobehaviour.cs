using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCKHMonobehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {

        loadComponets();
    }
    protected virtual void Awake()
    {
        this.Reset();
    }
    protected virtual void loadComponets()
    {
        //this.loadPrefabs();
    }
}
