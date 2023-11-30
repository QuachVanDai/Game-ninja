using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;

public class monster:MonoBehaviour,currentObject
{
    public int _id;
    public string _name;
    public string _level;
    public int _exp;
    public int _hp;
    public int _damage;

    public Image fill_bar;

    public monster(int id,string name, int hp,int damage)
    {
        this._id = id;
        this._name = name;
        this._hp = hp;
        this._damage = damage;
    }
    public monster GetMonster()
    {
        return this;
    }
    public void update_hp(int currency_blood, int max_blood)
    {
        fill_bar.fillAmount = (float)currency_blood / (float)max_blood;
    }
  
}
