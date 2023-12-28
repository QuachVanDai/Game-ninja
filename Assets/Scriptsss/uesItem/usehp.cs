using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class usehp: useItem
{
    // Start is called before the first frame update
    public hpSO hpSO;
    public int quanitity = 0;
    public TextMeshProUGUI txt_quanitity;
    public bool flat;
    public Image Fill_time;
    private float getTime;
    private inventoryManager inventory;
    public override void uses()
    {
        TextTemplate.Instance.SetText("su dung hp");
    }
    void Start()
    {
        inventory = FindObjectOfType<inventoryManager>();
        quanitity = inventory.updateHP(0);
        txt_quanitity.text = quanitity.ToString();
        flat = true;
    }
    public void useItemhp()
    {
        if(flat) { StartCoroutine(setTimeUse()); }
        else { TextTemplate.Instance.SetText(TagScript.hoiChieu); }
    }
    public IEnumerator setTimeUse()
    {
        if (quanitity > 0)
        {
            getTime = Time.time;
            flat = false;
            if(Player.Instance._currhp== Player.Instance.HP)
            {
                TextTemplate.Instance.SetText(TagScript.fullHP);
                yield return null;
                flat = true;
            }
            else
            {
                Player.Instance.update_hp(hpSO.hP);
                quanitity = inventory.updateHP(-1);
                txt_quanitity.text = quanitity.ToString();
                inventory.RefreshUI();
                yield return new WaitForSeconds(1);
                flat = true;
            }
           
        }
        else { TextTemplate.Instance.SetText(TagScript.notHp); }
    }
    // Update is called once per frame
    void Update()
    {
        quanitity = inventory.updateHP(0);
        txt_quanitity.text = quanitity.ToString();
        if (Input.GetKeyUp(KeyCode.E))
        {
            useItemhp();
        }
        if(!flat)
        {
            Fill_time.fillAmount = (Time.time - getTime) / 1;
        }
    }
}
