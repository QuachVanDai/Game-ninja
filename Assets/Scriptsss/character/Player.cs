using DG.Tweening;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : NCKHMonoBehaviour
{
    private static Player instance;
    public string _Name;
    private float _hp=10000;
    public float _currhp=10000;
    private float _mp=10000;
    public float _currmp=10000;
    public string _className; 
    public int _level=1;
    public float _percentExp;
    public int _gold;
    public numberTxt numberTxt;
    public Transform canvas;
    private Dictionary<int, Tuple<int, int>> playerDamage
        = new Dictionary<int, Tuple<int, int>>();
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
    public Exp x;

    public float HP { get { return _hp; } }
    public float MP { get { return _mp; } }
    public static Player Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        Player.instance = this;
    }
   
    protected override void loadComponets()
    {
        base.loadComponets();
        GameObject Object = GameObject.Find("txt_hp");
        currentHP = Object.GetComponent<TextMeshProUGUI>();
        Object = GameObject.Find("txt_mp");
        currentMP = Object.GetComponent<TextMeshProUGUI>();
        Object = GameObject.Find("percentage");
        currentPercentExp = Object.GetComponent<TextMeshProUGUI>();
        Object = GameObject.Find("level");
        currentLevel = Object.GetComponent<TextMeshProUGUI>();
                Object = GameObject.Find("full_hp");
        fill_bar_HP = Object.GetComponent<Image>();
                Object = GameObject.Find("full_mp");
        fill_bar_MP = Object.GetComponent<Image>();
        setPlayerDamage();
        currentName.text = _Name.ToString();
        currentLevel.text = _level.ToString();
        currentPercentExp.text = _percentExp.ToString("F2")+"%";
        _hp = _currhp;
        _mp = _currmp;
        update_hp(this._hp, this._hp,this._hp.ToString());
        update_mp(this._mp, this._mp, this._mp.ToString());
        numberTxt = new numberTxt();
    }
    public TextMeshProUGUI txt_damaged;

    public Tuple<int, int> getDamage(int index)
    {
        Tuple<int, int> g = playerDamage[index];
        return g;
    }
    public void setPlayerDamage()
    {
        int min_d=110, max_d=120;
        for (int i = 1; i <= 20; i++)
        {
            playerDamage.Add(i  , new Tuple<int, int>(min_d, max_d));
            min_d += 30;
            max_d += 30;
        }
    }
    public Player GetCharacter()
    {
        return this;
    }
    public void update_hp(float currency_hp, float max_hp, string text)
    {
         fill_bar_HP.fillAmount = (float)currency_hp/ (float)max_hp;
        currentHP.text = text;
    }
    public void update_mp(float currency_mp, float max_mp, string text)
    {
        fill_bar_MP.fillAmount = (float)currency_mp / (float)max_mp;
        currentMP.text = text;
    }


}
