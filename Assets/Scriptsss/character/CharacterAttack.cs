using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterAttack:MonoBehaviour
{
    public static CharacterAttack instance;
    private bool isActtack;
    private Animator animator;
    [SerializeField] SkillAnimation skillAnimation;
    [SerializeField] FrameSkill frameSkill;
    CharacterController2D characterController;

    private float distance; 
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
    private void Update()
    {
        if (characterController.isGround() == false) return;
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (mon == null) { Debug.Log("Khoong co muc tieu"); return; }
            distance = Vector2.Distance(transform.position, mon.transform.position);
            if ( distance>4) { Debug.Log("khoangr cacsh qua xa"); return; };
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
        animator.SetBool("IsAttack", true);
        isActtack = false;
        yield return new WaitForSeconds(0.23f);
        animator.SetBool("IsAttack", false);
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