using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack:MonoBehaviour
{
    public static CharacterAttack instance;
    public bool isActtack;
    private Animator animator;
    [SerializeField] SkillAnimation skillAnimation;
    [SerializeField] FrameSkill frameSkill;
    CharacterController2D characterController;


    public monsterAttacked mon;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        characterController = GetComponent<CharacterController2D>();
        isActtack = true;
        animator = GetComponent<Animator>();

    }
    public  IEnumerator playerAttack()
    {
        skillAnimation.AnimationSkill(frameSkill);
        animator.SetBool("IsAttack", true);
        isActtack = false;
        Debug.Log(isActtack);
        yield return new WaitForSeconds(0.23f);
        animator.SetBool("IsAttack", false);
        yield return new WaitForSeconds(0.5f);
        isActtack = true;
    }
    private void Update()
    {
        if (characterController.isGround() == false) return;
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (isActtack)
            {
                StartCoroutine(playerAttack());
                if(mon==null) { Debug.Log("Khoong co muc tieu");return; }
                mon.Attacked(51);
            }
        }
    }

    
    public void findMonster(monsterAttacked m)
    {
        mon = m.GetComponent<monsterAttacked>();
    }
}