using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAttack:NCKHMonoBehaviour
{
    private bool isActtack,isSkillLv5,isSkillLv15,isIncreaseDamage;
    [SerializeField] SkillAnimation skillAnimation;
    [SerializeField] FrameSkill[] frameSkill;
    private float distance; 
    public monsterAttacked monsterAttacted;
    private Exp ex =new Exp();
    private setSkillParameters skillParameters = new setSkillParameters();

    protected override void loadComponets()
    {
     //   frameSkill = new FrameSkill[frameSkill.Length];
        base.loadComponets();
        Transform g =  transform.Find("skillAnimation");
        skillAnimation = g.GetComponent<SkillAnimation>();
    }
    private void Start()
    {
        isActtack = true;
        isSkillLv5 = true;
        isSkillLv15 = true;
        isIncreaseDamage = false;
    }

    private void Update()
    {
        //  
        if( gameManager.Instance.IsPlaygame == false) return;
        // check to see if player is standing on the ground ?
        if (PlayerController2D.Instance.isGround() == false) return;

        if(PlayerController2D.Instance.getInputSpace())
        {
            // Check if the target has been selected?
            if (monsterAttacted == null)
            {
                //systemUi.Instance.infoMonster.gameObject.SetActive(false);
                Debug.Log("Khong co muc tieu"); return; 
            }

            // Calculate the distance from the player to the target
            distance = Vector2.Distance(transform.position, monsterAttacted.transform.position);
            // 
            if ( distance>4) { Debug.Log("khoang cach qua xa"); return; }

            // if player use skilllv5 or skilllv15  , player cannot attack.
            if (useSkill.Instance.getCurrKeySkill() == 1 || useSkill.Instance.getCurrKeySkill() == 3){  Debug.Log("Skill khong phu hop"); return;}
            // check mana
            ManaUseSkill();
            // player can attack
            if (isActtack)
            {
                StartCoroutine(playerAttack());
            }
        }
    }
    public IEnumerator playerAttack()
    {
        // 
        float damage = Random.Range(Player.Instance._setPlayer.getDamePlayerDictionary(Player.Instance._level).Item1,
            Player.Instance._setPlayer.getDamePlayerDictionary(Player.Instance._level).Item2) *
            frameSkill[useSkill.Instance.getCurrKeySkill()].coefficient;

        // if player use skillLv15 , player can increase damage
        if (isIncreaseDamage)
        {
            if (Player.Instance._level >= 20)
                damage += skillParameters.getSkillLv15Parameters()[6];
            else { damage += skillParameters.getSkillLv15Parameters()[Player.Instance._level - 14]; }
        }
        AddExp((int)damage);
        monsterAttacted.Attacked((int)damage);
        skillAnimation.AnimationSkill(frameSkill[useSkill.Instance.getCurrKeySkill()]);
        PlayerController2D.Instance.Animator.SetBool("IsAttack", true);
        //animator.SetBool("IsAttack", true);
        isActtack = false;
        Player.Instance._currmp -= frameSkill[useSkill.Instance.getCurrKeySkill()].mp;
        Player.Instance.update_mp(Player.Instance._currmp, Player.Instance.MP, Player.Instance._currmp.ToString());
        yield return new WaitForSeconds(0.23f);
        PlayerController2D.Instance.Animator.SetBool("IsAttack", false);
        // animator.SetBool("IsAttack", false);
        yield return new WaitForSeconds(frameSkill[useSkill.Instance.getCurrKeySkill()].timeSkill);
        isActtack = true;

    }
    public void AddExp(float damage)
    {
        if (monsterAttacted.currMoster._currhp < damage)
        {
            damage = monsterAttacted.currMoster._currhp;
        }
            double exp = (damage * ex.getExpMonsterDictionary()[monsterAttacted.currMoster._level]*100 )
            / ex.getExpPlayerDictionary()[Player.Instance._level];
        Player.Instance.numberTxt.aniTextY(Player.Instance.currentName, Player.Instance.canvas, Player.Instance.currentName.transform, (int)damage , new Vector3(0, 1.2f, 0), 1, 0.3f, Color.blue);
        if (Player.Instance._percentExp + exp > 100)
        {
            Player.Instance._percentExp = 0;
            Player.Instance._level++;
            Player.Instance.currentLevel.text = Player.Instance._level.ToString();
        }
        else Player.Instance._percentExp +=(float) exp;
        Player.Instance.currentPercentExp.text = (Player.Instance._percentExp).ToString("F2") + "%";
    }
    public void playerUseSkillLv5()
    {
        if (useSkill.Instance.getIsUseSkill(1) == false) {  return; }
        ManaUseSkill();
        if (!isSkillLv5) { Debug.Log("Dang hoi chieu"); return; }
        if (isSkillLv5)
        {
            StartCoroutine(UseSkillLv5());
        }
    }
    public IEnumerator UseSkillLv5()
    {
        skillAnimation.AnimationSkillLv5_15(frameSkill[1]);
        isSkillLv5 = false;
        InvokeRepeating(nameof(inCreaseHPMP), 0, 0.5f);
        yield return new WaitForSeconds(1.5f);
        CancelInvoke(nameof(inCreaseHPMP));
        yield return new WaitForSeconds(frameSkill[1].timeSkill);
        isSkillLv5 = true;
    }
    public void inCreaseHPMP()
    {
        if (Player.Instance._level >= 10)
        {
            Player.Instance._currhp += skillParameters.getSkillLv5Parameters()[6];
            Player.Instance._currmp += skillParameters.getSkillLv5Parameters()[6];
        }
        else
        { 
            Player.Instance._currhp += skillParameters.getSkillLv5Parameters()[Player.Instance._level - 4]; 
            Player.Instance._currmp += skillParameters.getSkillLv5Parameters()[Player.Instance._level - 4]; 
        }
        if (Player.Instance._currhp >= Player.Instance.HP)
        {
            Player.Instance.update_hp(Player.Instance.HP, Player.Instance.HP, Player.Instance.HP.ToString());
            Player.Instance._currhp = Player.Instance.HP;
        }
        if (Player.Instance._currmp >= Player.Instance.MP)
        {
            Player.Instance.update_mp(Player.Instance.MP, Player.Instance.MP, Player.Instance.MP.ToString());
            Player.Instance._currmp = Player.Instance.MP;
        }
        Player.Instance.update_hp(Player.Instance._currhp, Player.Instance.HP, Player.Instance._currhp.ToString());
        Player.Instance.update_mp(Player.Instance._currmp, Player.Instance.MP, Player.Instance._currmp.ToString());
    }
    public void playerUseSkillLv15()
    {
        if (useSkill.Instance.getIsUseSkill(3) == false) { return; }
        ManaUseSkill();
        if (!isSkillLv15) { Debug.Log("Dang hoi chieu"); return; }
        if (isSkillLv15)
        {
            StartCoroutine(UseSkillLv15());
        }
    }


    public IEnumerator UseSkillLv15()
    {
        skillAnimation.AnimationSkillLv5_15(frameSkill[3]);
        isSkillLv15 = false;
        isIncreaseDamage = true;
        yield return new WaitForSeconds(frameSkill[3].timeSkill);
        isSkillLv15 = true;
        isIncreaseDamage = false;
    }
 
    public  void findMonster(monsterAttacked m)
    {
        monsterAttacted = m.GetComponent<monsterAttacked>();
    }
    public void ManaUseSkill()
    {
        if (Player.Instance._currmp < frameSkill[useSkill.Instance.getCurrKeySkill()].mp)
        {
            Debug.Log("khong du Mana de su dung  " + Player.Instance._currmp);
            return;
        }

    }
    void OnDrawGizmos()
    {
        if (monsterAttacted == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, monsterAttacted.transform.position);
    }
}