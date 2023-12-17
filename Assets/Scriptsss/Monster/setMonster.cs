using System;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class setMonster
{
    private Dictionary<int, double> ExpMonster
    = new Dictionary<int, double>();
    private Dictionary<int, int> HPMonster
    = new Dictionary<int, int>();
    private Dictionary<int, Tuple<int, int>> DameMonster
    = new Dictionary<int, Tuple<int, int>>();



    public setMonster()
    {
        setExpMonsterDictionary();
        setHPMonsterDictionary();
        setDameMonsterDictionary();
    }
    public Dictionary<int, double> getExpMonsterDictionary()
    {
        return ExpMonster;
    }
    public void setExpMonsterDictionary()
    {
        for (int i = 1; i <= 20; i++)
        {
            ExpMonster.Add(i, 0.5f * Math.Pow(i, 0.8f));
        }
    }

    public Dictionary<int, int> getHPMonsterDictionary()
    {
        return HPMonster;
    }
    public void setHPMonsterDictionary()
    {
        for (int i = 1; i <= 20; i++)
        {
            double v = Math.Round(500 * Math.Pow(i, 0.6f));
            HPMonster.Add(i, (int)v);
        }

    }
    public Tuple<int, int> getDameMonsterDictionary(int index)
    {
        Tuple<int, int> g = DameMonster[index];
        return g;
    }
    public void setDameMonsterDictionary()
    {
        int min_d = 40, max_d = 50;
        for (int i = 1; i <= 20; i++)
        {
            DameMonster.Add(i, new Tuple<int, int>(min_d, max_d));
            min_d += 20;
            max_d += 20;
        }
    }


  
}
