using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useSkill : NCKHMonoBehaviour
{
    private static useSkill instance;
    private int currKeySkill;
    private int lastKeySkill;
    [SerializeField] protected bool[] isUseSkill;

    public static useSkill Instance {  get { return instance; } }
    protected override void Awake()
    {
        base.Awake();
        useSkill.instance = this;
    }
    protected override void loadComponets()
    {
        base.loadComponets();
        isUseSkill =  new bool[5];
        Array.Fill(isUseSkill, false);
        // currLevel = Player.Instance._level;
    }

    public void use()
    {
        if (Player.Instance._level < 5) { setIsUseSkill(0);  return; }
        if (Player.Instance._level < 10) { setIsUseSkill(1);  return; }
        if (Player.Instance._level < 15) { setIsUseSkill(2);  return; }
        if (Player.Instance._level < 20) { setIsUseSkill(3);  return; }
        if (Player.Instance._level < 25) { setIsUseSkill(4);  return; }
    }
    public bool getIsUseSkill(int index)
    {
        return isUseSkill[index];
    }
    public void setIsUseSkill(int z)
    {
        for (int i = 0; i<=z; i++)
        {
            isUseSkill[i] = true;
        }
    }
    public int getCurrKeySkill()
    {
        return currKeySkill;
    }
    public void SetCurrKeySkill(int key)
    {
        if (!isUseSkill[key/5]) { return; }
        this.currKeySkill = key / 5;
    }
    public int getLastKeySkill()
    {
        return lastKeySkill;
    }
    public void SetLastKeySkill(int key)
    {
        this.lastKeySkill = this.currKeySkill;
    }
 
}
