using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class describeSkill : NCKHMonoBehaviour
{
    
    public Transform[] lstSelect;
    public TextMeshProUGUI txtSkill;
    private int key;
    private string[] desSkill;
    protected override void loadComponets()
    {
        base.loadComponets();
        findSelect();
    }
    private void Start()
    {
        hideSelect();
        setDesSkill();
    }
    public void getDesSkill()
    {
        hideSelect();
        txtSkill.text = desSkill[key];
    }

    public void setKey(int key)
    {
        this.key = key;
        getDesSkill();
    }
    public void findSelect()
    {
        lstSelect = new Transform[5];
        GameObject[] selectObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject selectObject in selectObjects)
        {
            if (selectObject.name == "select1_")
            {
                this.lstSelect[0] = selectObject.transform;
            }
            if (selectObject.name == "select2_")
            {
                this.lstSelect[1] = selectObject.transform;
            }
            if (selectObject.name == "select3_")
            {
                this.lstSelect[2] = selectObject.transform;
            }
            if (selectObject.name == "select4_")
            {
                this.lstSelect[3] = selectObject.transform;
            }
            if (selectObject.name == "select5_")
            {
                this.lstSelect[4] = selectObject.transform;
            }
        }
    }
    public void setDesSkill()
    {
         desSkill = new string[5];
        desSkill[0] = "Chiêu Cơ bản\nĐao pháp nhập môn dùng đao chém mạnh vào mục tiêu gây sát thương lên mục tiêu đó.";
        desSkill[1] = "Chiêu Hồi phục\nNhẫn thật tâm pháp giúp bản thân tăng hp mp. ";
        desSkill[2] = "Chieu Trung cap \nPhóng ra nhưng tia lôi điện giáng những đòn chí mạng vào kẻ địch.";
        desSkill[3] = "Chiêu Tăng sức mạnh \nNhẫn thật tâm pháp giúp bản thân tăng lượng sát thương vào kẻ địch.  ";
        desSkill[4] = "Chiêu Cao cấp \nChiêu thức kêu gọi Lôi Mã Phong Vân tấn công mạnh mẽ vào kẻ địch.";
    }
    public void hideSelect()
    {
        foreach(Transform t in lstSelect) 
        {
            t.gameObject.SetActive(false);
        }
    }
}
