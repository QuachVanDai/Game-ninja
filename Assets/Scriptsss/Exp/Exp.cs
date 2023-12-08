using System;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public  class Exp
{
    private  int _key;
    private  int _value;
    private  Dictionary<int, int> ExpPlayer 
        = new Dictionary<int, int>();
    private  Dictionary<int, double>  ExpMonster
        = new Dictionary<int, double>();
    public  int Key
    {
        get { return _key; }
        set { _key = value; }
    }
    public  int Value
    {
        get { return _value; }
        set { this._value = value; }
    }
    public Exp()
    {
        setExpPlayerDictionary();
        setExpMonsterDictionary();
    }
 
    public  Dictionary<int, int>  getExpPlayerDictionary()
    {
        return ExpPlayer;
    }
    public  Dictionary<int, double> getExpMonsterDictionary()
    {
        return ExpMonster;
    }
    public  void setExpPlayerDictionary()
    {
        for(int i=1;i <=20; i++) 
        {
            double v = Math.Round(1300 * Math.Pow(i, 0.8f));
            ExpPlayer.Add(i,  (int)v);
        }
        
    }
    public  void setExpMonsterDictionary()
    {
        for (int i = 1; i <= 20; i++)
        {
            ExpMonster.Add(i, 0.5f * Math.Pow(i, 0.8f));
        }
    }
}
