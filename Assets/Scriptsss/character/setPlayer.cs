using System;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class setPlayer
{
  
    private Dictionary<int, int> ExpPlayer
        = new Dictionary<int, int>();
    private Dictionary<int, int> HPPlayer
    = new Dictionary<int, int>();
    private Dictionary<int, int> MPPlayer
    = new Dictionary<int, int>();
    private Dictionary<int, Tuple<int, int>> DamePlayer
    = new Dictionary<int, Tuple<int, int>>();

    private Dictionary<int, double> ExpMonster
        = new Dictionary<int, double>();
  
    public setPlayer()
    {
        setExpPlayerDictionary();
        setHPPlayerDictionary();
        setMPPlayerDictionary();
        setDamePlayerDictionary();
    }

    public Dictionary<int, int> getExpPlayerDictionary()
    {
        return ExpPlayer;
    }
  
    public void setExpPlayerDictionary()
    {
        for (int i = 1; i <= 20; i++)
        {
            double v = Math.Round(1500 * Math.Pow(i, 1.5f));
            ExpPlayer.Add(i, (int)v);
        }

    }
    public Dictionary<int, int> getHPPlayerDictionary()
    {
        return HPPlayer;
    }
    public void setHPPlayerDictionary()
    {
        for (int i = 1; i <= 20; i++)
        {
            double v = Math.Round(500 * Math.Pow(i, 0.6f));
            HPPlayer.Add(i, (int)v);
        }

    }
    public Dictionary<int, int> getMPPlayerDictionary()
    {
        return MPPlayer;
    }
    public void setMPPlayerDictionary()
    {
        for (int i = 1; i <= 20; i++)
        {
            double v = Math.Round(500 * Math.Pow(i, 0.6f));
            MPPlayer.Add(i, (int)v);
        }
    }
    public Tuple<int, int> getDamePlayerDictionary(int index)
    {
        Tuple<int, int> g = DamePlayer[index];
        return g;
    }
    public void setDamePlayerDictionary()
    {
        int min_d = 110, max_d = 120;
        for (int i = 1; i <= 20; i++)
        {
            DamePlayer.Add(i, new Tuple<int, int>(min_d, max_d));
            min_d += 30;
            max_d += 30;
        }
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
}
