using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterAttack:MonoBehaviour
{
    public static CharacterAttack instance;
    private bool isActtack;
    private Animator animator;
    private int max_mp;

    [SerializeField] SkillAnimation skillAnimation;
    [SerializeField] FrameSkill frameSkill;

    private float distance; 
    public monsterAttacked mon;
    public Character character;


    private void Awake()
    {
        instance = this;
       
    }
    private void Start()
    {
        character = GetComponent<Character>();
        isActtack = true;
        max_mp = character._mp;
    }
    private void Update()
    {
        if (CharacterController2D.Instance.isGround() == false) return;
        if(CharacterController2D.Instance.getInputSpace())
        {
            if (mon == null) { Debug.Log("Khoong co muc tieu"); return; }
            distance = Vector2.Distance(transform.position, mon.transform.position);
            if ( distance>4) { Debug.Log("khoangr cacsh qua xa"); return; };
            if (character._mp<10) { Debug.Log("khoong du nang luong"); return; };
            if (isActtack)
            {
                StartCoroutine(playerAttack());
                
                mon.Attacked(51);
            }
        }
    }
    public IEnumerator playerAttack()
    {
        skillAnimation.AnimationSkill(frameSkill);
        CharacterController2D.Instance.Animator.SetBool("IsAttack", true);
        //animator.SetBool("IsAttack", true);
        isActtack = false;
        character._mp -= frameSkill.mp;
        character.update_mp(character._mp, max_mp);
        character.currentMP.text = character._mp.ToString();
        yield return new WaitForSeconds(0.23f);
        CharacterController2D.Instance.Animator.SetBool("IsAttack", false);
       // animator.SetBool("IsAttack", false);
        yield return new WaitForSeconds(0.5f);
        isActtack = true;
    }

    public void findMonster(monsterAttacked m)
    {
        mon = m.GetComponent<monsterAttacked>();

    }
    void OnDrawGizmos()
    {
        if (mon == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, mon.transform.position);
    }
}