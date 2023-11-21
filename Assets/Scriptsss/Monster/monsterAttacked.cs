using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterAttacked : MonoBehaviour
{

    public  monster ob_mon;
    public Image fill_bar;
    public int max_hp;
    public  monster GetMonster() { return this.ob_mon; }
    void Start()
    {
       ob_mon = GetComponent<monster>();
        max_hp = ob_mon._hp;
    }
    public void update_blood(int currency_blood, int max_blood)
    {
        fill_bar.fillAmount = (float)currency_blood / (float)max_blood;
    }
    private void OnMouseDown()
    {

        CharacterAttack.instance.findMonster(this);
    }
    public void Attacked(int damage)
    {
        ob_mon._hp -= damage;
        if (ob_mon._hp < 0)
        {
            Destroy(gameObject);
        }
        update_blood(ob_mon._hp, max_hp);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
