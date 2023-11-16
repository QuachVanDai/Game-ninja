using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None, Potion, Equipment, Quest
}

public class ItemSO: ScriptableObject
{
    public int id;
    public new string name;
    public Sprite icon;
    public int powerRequired;
    public string Description;
    public ItemType itemType;


    public void OnEnable()
    {
        this.Update();
    }

    public virtual void Update()
    {
        if(this.icon != null )
        {
            this.id = int.Parse(this.icon.name);
        }    
    }

    private Sprite[] spriteIdle;
    public Sprite[] GetSpriteIdle
    {
        get { return this.spriteIdle; }
    }
    public void SetSpriteIdle(Sprite[] sprite)
    {
        this.spriteIdle = sprite;
    }    


    private Sprite[] spriteRun;
    public Sprite[] GetSpriteRun
    {
        get { return this.spriteRun; }
    }
    public void SetSpriteRun(Sprite[] sprite)
    {
        this.spriteRun = sprite;
    }


    private Sprite[] spriteAttack;
    public Sprite[] GetSpriteAttack
    {
        get { return this.spriteAttack; }
    }
    public void SetSpriteAttack(Sprite[] sprite)
    {
        this.spriteAttack = sprite;
    }
    private Sprite[] spriteDown;
    public Sprite[] GetSpriteDown
    {
        get { return this.spriteDown; }
    }
    public void SetSpriteDown(Sprite[] sprite)
    {
        this.spriteDown = sprite;
    }
}
