using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Character : MonoBehaviour, currentObject
{
    public string _Name;
    public int _hp;
    public int _mp;
    public string _className;
    public int _minDamage;
    public int _maxDamage;
    public int _level;
    public float _percentExp;
    public int _gold;

    public TextMeshProUGUI currentName;
    public TextMeshProUGUI currentHP;
    public TextMeshProUGUI currentMP;
    public TextMeshProUGUI currentClassName;
    public TextMeshProUGUI currentMinDamage;
    public TextMeshProUGUI currentMaxDamage;
    public TextMeshProUGUI currentLevel;
    public TextMeshProUGUI currentPercentExp;
    public TextMeshProUGUI currentGold;


    [SerializeField] private Image fill_bar_HP;
    [SerializeField] private Image fill_bar_MP;
    private void Start()
    {
        update_hp(this._hp, this._hp);
        update_hp(this._mp,this._mp);
    }
    public Character GetCharacter()
    {
        return this;
    }
    public void update_hp(int currency_hp, int max_hp)
    {
         fill_bar_HP.fillAmount = (float)currency_hp/ (float)max_hp;
    }
    public void update_mp(int currency_mp, int max_mp)
    {
        fill_bar_MP.fillAmount = (float)currency_mp / (float)max_mp;
    }

}
