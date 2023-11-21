using System.Collections;
using UnityEngine;
using System;
public class monster:MonoBehaviour
{
    public int _id;
    public string _name;
    public string _level;
    public int _hp;
    public int _damage;
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
    private void OnMouseDown()
    {


    }
}
