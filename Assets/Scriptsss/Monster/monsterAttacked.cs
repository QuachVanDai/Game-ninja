using System.Collections;
using UnityEngine;

public class monsterAttacked : NCKHMonoBehaviour
{
    private monsterController2D monsterController2D;
    public monster currMoster;
    public Transform selected;
    public Transform ani_Attacked;
    public PlayerAttack PlayerAttack;
    public junkSO junkSO;
    void Start()
    {
        monsterController2D = GetComponent<monsterController2D>();
        currMoster = GetComponent<monster>();
    }
    protected override void loadComponets()
    {
        base.loadComponets();
        selected = transform.Find("selected");
        ani_Attacked = transform.Find("ani_Attacked");
        GameObject player = GameObject.FindWithTag("player");
        PlayerAttack = player.GetComponent<PlayerAttack>();
    }
    public void Update()
    {
        if (PlayerAttack.monsterAttacted == this) 
        { 
            selected.gameObject.SetActive(true);
            
        }
        else 
        {
            selected.gameObject.SetActive(false);
        }
    }
   
    private void OnMouseDown()
    {
        PlayerAttack.findMonster(this);
        currMoster.update_hp(currMoster._currhp, currMoster.HP,currMoster._name);
    }
    public void Attacked(int damage)
    {
        currMoster._currhp -= damage;
        StartCoroutine(aniAcctacked());
        currMoster.textGUI( damage*(-1), new Color(1,1,1));
        itemDropSpawner.Instance.Drop(junkSO.dropRateList,transform.position,Quaternion.identity);
        if (currMoster._currhp < 0)
        {
            currMoster.update_hp(0, currMoster.HP, currMoster._name);
            // i.Die(transform.position,Quaternion.identity);
            systemUi.Instance.infoMonster.gameObject.SetActive(false);
            monsterController2D.PlayAnimation(monsterStatus.death);
            Destroy(gameObject,0.5f);
            return;
        }
       currMoster.update_hp(currMoster._currhp, currMoster.HP,currMoster._name);
    }

    IEnumerator aniAcctacked()
    {
        ani_Attacked.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        ani_Attacked.gameObject.SetActive(false);
    }
}
