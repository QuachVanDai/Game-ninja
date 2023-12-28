using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : NCKHMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> lstPrefas;
    protected override void loadComponets()
    {
        this.loadPrefabs();
    }
    protected virtual void loadPrefabs()
    {
        if (lstPrefas.Count > 0) { return; }
        Transform prefabsOb = transform.Find("prefabs");
        if(prefabsOb == null) { Debug.Log("prefabs null"); }
        foreach(Transform g in prefabsOb)
        {
            this.lstPrefas.Add(g);
        }
        this.hidePrefabs();
    }
    protected virtual void hidePrefabs()
    {
        foreach (Transform g in lstPrefas)
        {
            g.gameObject.SetActive(false);
        }
    }
    public virtual Transform spawn(string prefabsName, Vector3 v3, Quaternion rotation)
    {
        if (this.getPrefabsByName(prefabsName) == null) 
        { 
            Debug.LogWarning("khong tim thay  " + prefabsName);
            return null;
        }
        Transform newPrefab = Instantiate(this.getPrefabsByName(prefabsName),v3, rotation);
        return newPrefab;
    }
    public virtual Transform getPrefabsByName(string prefabsName)
    {
        foreach(Transform g in lstPrefas)
        {
            if (g.name == prefabsName) return g;
        }
        return null;
    }
    public virtual List<Transform> getLstPrefabs()
    {
        return lstPrefas;
    }
 
}
