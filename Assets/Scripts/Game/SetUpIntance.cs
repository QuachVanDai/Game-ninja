using System.Collections.Generic;
using UnityEngine;

public class SetUpIntance : MonoBehaviour
{
    [SerializeField] private List<GameObject> intances;
    [SerializeField] private List<GameObject> objectAppears;
    [SerializeField] private List<GameObject> objectHidden;

    private void Awake()
    {
        foreach (GameObject intance in intances)
        {
            if (!intance.activeSelf)
            {
                intance.SetActive(true);
                intance.SetActive(false);
            }
        }
        if(objectAppears.Count > 0)
        {
            foreach (GameObject ob in objectAppears)
            {
                ob.SetActive(true);
            }
        }
        if (objectHidden.Count > 0)
        {
            foreach (GameObject ob in objectHidden)
            {
                ob.SetActive(false);
            }
        }
    }
}
