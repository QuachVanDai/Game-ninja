using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class usemp: useItem
{
    // Start is called before the first frame update
    public mpSO mpSO;
    public int quanitity = 0;
    public TextMeshProUGUI txt_quanitity;
    public bool flat;
    public Image Fill_time;
    private float getTime;
    private inventoryManager inventory;
    public override void uses()
    {
        TextTemplate.Instance.SetText("su dung mp");
    }
    void Start()
    {
        inventory = FindObjectOfType<inventoryManager>();
        quanitity = inventory.updateMP(0);
        txt_quanitity.text = quanitity.ToString();
        flat = true;
    }
    public void useItemmp()
    {
        if(flat) { StartCoroutine(setTimeUse()); }
        else { TextTemplate.Instance.SetText(TagScript.hoiChieu); }
    }
    public IEnumerator setTimeUse()
    {
        if(quanitity>0)
        {
            getTime = Time.time;
            flat = false;
            if (Player.Instance._currmp == Player.Instance.MP)
            {
                TextTemplate.Instance.SetText(TagScript.fullMP);
                yield return null;
                flat = true;
            }
            else
            {
                Player.Instance.update_mp(mpSO.MP);
                quanitity = inventory.updateMP(-1);
                txt_quanitity.text = quanitity.ToString();
                inventory.RefreshUI();
                yield return new WaitForSeconds(1);
                flat = true;
            }
        }
        else
        {
            TextTemplate.Instance.SetText(TagScript.notMp);
        }

    }
    // Update is called once per frame
    void Update()
    {
        quanitity = inventory.updateMP(0);
        txt_quanitity.text = quanitity.ToString();
        if (Input.GetKeyUp(KeyCode.R))
        {
            useItemmp();
        }
        if(!flat)
        {
            Fill_time.fillAmount = (Time.time - getTime) / 1;
        }
    }
}
