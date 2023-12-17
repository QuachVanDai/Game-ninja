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
    public Transform canvas;
    public Image fill_bar;
    public setMonster _setMonster = new setMonster();
    public numberTxt numberTxt;
    public TextMeshProUGUI numberText;
    public float HP { get { return this._hp; } }
    protected override void loadComponets()
    {
        base.loadComponets();
        //  _currhp = e.getExpMonsterTuple(1).Item1;

        numberTxt =  new numberTxt();
    }
    private void Start()
    {
        _currhp = _setMonster.getHPMonsterDictionary()[_level];
        this._hp = _currhp;
    }
    public monster GetMonster()
    {
        return this;
    }

    public void update_hp(float currency_blood, float max_blood,string _name)
    {
        fill_bar.fillAmount = (float)currency_blood / (float)max_blood;
        systemUi.Instance.infoMonster.text = " " + _name + "  " + currency_blood.ToString() +"/"+ max_blood.ToString();
        systemUi.Instance.infoMonster.gameObject.SetActive(true);
    }

}
