using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSkillParameters
{
    private Dictionary<int, int> skilllv5 = new Dictionary<int, int>();
    private Dictionary<int, int> skilllv15 = new Dictionary<int, int>();

    public setSkillParameters() { setParameters(); }
    public void setParameters()
    {
        for (int i = 1; i <= 6; i++)
        {
            double v = Math.Round(20 * Math.Pow(i, 0.8f));
            skilllv5.Add(i, (int)v);
        }
        for (int i = 1; i <= 6; i++)
        {
            double v = Math.Round(10 * Math.Pow(i, 0.7f));
            skilllv15.Add(i, (int)v);
        }
    }
    public Dictionary<int, int> getSkillLv5Parameters()
    {
        return skilllv5;
    }
    public Dictionary<int, int> getSkillLv15Parameters()
    {
        return skilllv15;
    }
}
