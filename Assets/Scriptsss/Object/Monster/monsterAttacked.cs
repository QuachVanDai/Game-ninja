using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterAttacked : MonoBehaviour
{
    private monsterController2D monsterController2D;
    public monster currMoster;
    public int max_hp;
    public GameObject selected;
    public GameObject ani_Attacked;
    public item i;
    void Start()
    {
        monsterController2D = GetComponent<monsterController2D>();
        currMoster = GetComponent<monster>();
        max_hp = currMoster._hp;
    }
    public void Update()
    {
        if(CharacterAttack.instance.mon==this) { selected.SetActive(true); }
        else { selected.SetActive(false); }
    }
   
    private void OnMouseDown()
    {
        CharacterAttack.instance.findMonster(this);
    }
    public void Attacked(int damage)
    {
        currMoster._hp -= damage;
        StartCoroutine(aniAcctacked());
        if (currMoster._hp < 0)
        {
            i.Die(transform.position,Quaternion.identity);
            monsterController2D.PlayAnimation(monsterStatus.death);
            Destroy(gameObject,0.5f);
        }
       currMoster.update_hp(currMoster._hp, max_hp);
    }

    IEnumerator aniAcctacked()
    {
        ani_Attacked.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        ani_Attacked.SetActive(false);
    }
}
