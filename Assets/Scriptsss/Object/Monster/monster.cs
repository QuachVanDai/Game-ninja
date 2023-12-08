using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class monster:NCKHMonoBehaviour
{
    public int _id;
    public string _name;
    public int _level;
    public float _exp;
    private float _hp;
    public float _currhp;
    public float _damage;
    public float _number;
    public Image fill_bar;
    Exp e = new Exp();
    public TextMeshProUGUI txt_damaged;
    public float HP { get { return this._hp; } }
    protected override void loadComponets()
    {
        base.loadComponets();
      //  _currhp = e.getExpMonsterTuple(1).Item1;
        this._hp = _currhp;
        GameObject Object = GameObject.Find("txtdamaged");
        txt_damaged = Object.GetComponent<TextMeshProUGUI>();
        txt_damaged.gameObject.SetActive(false);
    }
    public monster(int id,string name,int level,float exp, float hp,float damage,float number)
    {
        this._id = id;
        this._name = name;
        this._level = level;
        this._exp = exp;
        this._hp = hp;
        this._damage = damage;
        this._number = number;
    }
    public monster GetMonster()
    {
        return this;
    }

    public void damaged(string damaged)
    {
        txt_damaged.transform.localScale = transform.localScale;
        txt_damaged.gameObject.SetActive(true);
        txt_damaged.text = damaged;
        txt_damaged.rectTransform.anchoredPosition = new Vector3(0,80,0);
        var t = txt_damaged.rectTransform.DOAnchorPosY(txt_damaged.rectTransform.localPosition.y + 50, 0.3f)
        .OnComplete(() => txt_damaged.gameObject.SetActive(false));
    }
    public void update_hp(float currency_blood, float max_blood,string _name)
    {
        fill_bar.fillAmount = (float)currency_blood / (float)max_blood;
        systemUi.Instance.infoMonster.text = " " + _name + "  " + currency_blood.ToString() +"/"+ max_blood.ToString();
        systemUi.Instance.infoMonster.gameObject.SetActive(true);
    }

}
