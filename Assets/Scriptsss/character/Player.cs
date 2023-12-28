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
    public float _currhp;
    public float _currmp;
    public string _className;
    public int _level;
    public float _percentExp;
    public int _gold;
    public int _minDamage;
    public int _maxDamage;
    public RectTransform canvas;

    public TextMeshProUGUI currentName;
    public TextMeshProUGUI currentHP;
    public TextMeshProUGUI currentMP;
    public TextMeshProUGUI currentClassName;
    public TextMeshProUGUI currentMinDamage;
    public TextMeshProUGUI currentMaxDamage;
    public TextMeshProUGUI currentLevel;
    public TextMeshProUGUI currentPercentExp;
    public TextMeshProUGUI currentGold;

    public GameObject txt_damaged;
    public Image fill_bar_HP;
    public Image fill_bar_MP;
    public setPlayer _setPlayer;

    private float _hp;
    private float _mp;

    public float HP { get { return _hp; } }
    public float MP { get { return _mp; } }
    public static Player Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        Player.instance = this;
    }
    public void textGUI(int damage,Color color)
    {
        GameObject g = Instantiate(txt_damaged);
          numberTxt numberTxt = g.GetComponent<numberTxt>();
        numberTxt.aniTextY1(canvas,(int)damage, new Vector3(0, 1.2f, 0), 1, 0.5f, color);
    }
    protected override void loadComponets()
    {
        base.loadComponets();
        _setPlayer = new setPlayer();
        _level = 1;
        _minDamage = _setPlayer.getDamePlayerDictionary(_level).Item1;
        _maxDamage = _setPlayer.getDamePlayerDictionary(_level).Item2;
        _currhp = _setPlayer.getHPPlayerDictionary()[_level];
        _currmp = _setPlayer.getMPPlayerDictionary()[_level];
        _hp = _currhp;
        _mp = _currmp;

      //  numberTxt =  txt_damaged.GetComponent<numberTxt>();

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

        Object = GameObject.Find("PlayerCanvas");
        canvas = Object.GetComponent<RectTransform>();

        Object = GameObject.Find("NamePlayer");
        currentName = Object.GetComponent<TextMeshProUGUI>();

        currentName.text = _Name.ToString();
        currentLevel.text = _level.ToString();
        currentPercentExp.text = _percentExp.ToString("F2")+"%";
        update_hp(0);
        update_mp(0);
    }

 
    public Player GetCharacter()
    {
        return this;
    }
    public void update_hp(float hp)
    {
        _currhp += hp;
        _currhp = _currhp >= HP?HP:_currhp;
        fill_bar_HP.fillAmount = _currhp / HP;
        currentHP.text = _currhp.ToString();
    }
    public void update_mp(float mp)
    {
        _currmp += mp;
        _currmp = _currmp >= MP ? MP : _currmp;
        fill_bar_MP.fillAmount = _currmp / MP;
        currentMP.text =_currmp.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "potion")
        {
            useItem i = collision.gameObject.GetComponent<useItem>();
            inventoryManager.Instance.Add(i.item,1);
        }
    }

}
