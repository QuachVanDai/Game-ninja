using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterAttacked : MonoBehaviour
{
    private monsterController2D monsterController2D;
    public monster ob_mon;
    public Image fill_bar;
    public int max_hp;
    public GameObject selected;
    public GameObject ani_Attacked;
    public  monster GetMonster() { return this.ob_mon; }
    void Start()
    {
        monsterController2D = GetComponent<monsterController2D>();
        ob_mon = GetComponent<monster>();
        max_hp = ob_mon._hp;
    }
    public void Update()
    {
        if(CharacterAttack.instance.mon==this) { selected.SetActive(true); }
        else { selected.SetActive(false); }
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
        StartCoroutine(aniAcctacked());
        if (ob_mon._hp < 0)
        {
            monsterController2D.PlayAnimation(monsterStatus.death);
            Destroy(gameObject,0.5f);
        }
        update_blood(ob_mon._hp, max_hp);
    }

    IEnumerator aniAcctacked()
    {
        ani_Attacked.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        ani_Attacked.SetActive(false);
    }
    // Update is called once per frame
}
