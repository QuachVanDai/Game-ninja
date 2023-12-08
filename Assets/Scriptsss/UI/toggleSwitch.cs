
using UnityEngine;

public class toggleSwitch : MonoBehaviour
{
    public GameObject[] hiddenObject;
    public void Switch()
    {
        for(int i = 0; i < hiddenObject.Length; i++)
        {
            hiddenObject[i].SetActive(false);
        }
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
