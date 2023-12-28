using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class monster:NCKHMonoBehaviour
{
    public string _name;
    public int _level;
    public float _currhp;
    public int _minDamage;
    public int _maxDamage;
    public RectTransform canvas;
    public Image fill_bar;
    public setMonster _setMonster = new setMonster();
    public GameObject txt_damaged;

    private float _hp;

    public float HP { get { return this._hp; } }
    protected override void loadComponets()
    {
        base.loadComponets();
        GameObject Object = GameObject.Find("txt_hp");
    }
    
    public void textGUI(int damage, Color color)
    {
        
        GameObject g = Instantiate(txt_damaged);
        numberTxt numberTxt = g.GetComponent<numberTxt>();
        numberTxt.aniTextY1(canvas, (int)damage, new Vector3(0, 1.2f, 0), 1, 0.5f, color);
    }

    private void Start()
    {
        _currhp = _setMonster.getHPMonsterDictionary()[_level];
        _minDamage = _setMonster.getDameMonsterDictionary(_level).Item1;
        _minDamage = _setMonster.getDameMonsterDictionary(_level).Item2;
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
