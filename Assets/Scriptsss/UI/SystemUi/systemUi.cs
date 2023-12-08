using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class systemUi : NCKHMonoBehaviour
{
    private static systemUi instance;

    public TextMeshProUGUI infoMonster;
    public static systemUi Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake();
        systemUi.instance = this;
    }

    protected override void loadComponets()
    {
        base.loadComponets();
        GameObject Object = GameObject.Find("inforMonster");
        infoMonster = Object.GetComponent<TextMeshProUGUI>();
       infoMonster.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
