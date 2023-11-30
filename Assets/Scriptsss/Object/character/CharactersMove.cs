using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMove : MonoBehaviour
{
    [Header("Character")]
    [Space]
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;
    public float runSpeed = 0f;
    public bool m_FacingRight = true;
    private Rigidbody2D m_Rigidbody2D;
    private float moveInput = 0f;
    private float  jumpInput=0f;

    [SerializeField] private float jumpForce;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveInput = CharacterController2D.Instance.getInputHorizontal();
        jumpInput = CharacterController2D.Instance.getInputVertical();

        if (!CharacterController2D.Instance.isGround() && jumpInput == 0)
        {
          //  animator.SetBool("IsIdleToDown", true);
            CharacterController2D.Instance.Animator.SetBool("IsIdleToDown", true);
        }
        Move(runSpeed*moveInput);
        if (CharacterController2D.Instance.isGround())
        {
           // animator.SetBool("IsIdleToJump", false);
           // animator.SetBool("IsIdleToDown", false);
            CharacterController2D.Instance.Animator.SetBool("IsIdleToJump", false);
            CharacterController2D.Instance.Animator.SetBool("IsIdleToDown", false);

            if (jumpInput > 0 && m_Rigidbody2D.velocity.y == 0)
            {
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpForce);
                //animator.SetBool("IsIdleToJump", true);
                //animator.SetBool("IsIdleToDown", true);
                CharacterController2D.Instance.Animator.SetBool("IsIdleToJump", true);
                CharacterController2D.Instance.Animator.SetBool("IsIdleToDown", true);
            }
           // animator.SetFloat("Speed", Mathf.Abs(moveInput));
            CharacterController2D.Instance.Animator.SetFloat("Speed", Mathf.Abs(moveInput));

        }
        //animator.SetFloat("Jumping", m_Rigidbody2D.velocity.y);
        CharacterController2D.Instance.Animator.SetFloat("Jumping", m_Rigidbody2D.velocity.y);
    }

    public void Move(float move)
    {
        m_Rigidbody2D.velocity = new Vector2(move, m_Rigidbody2D.velocity.y);
        if (move > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (move < 0 && m_FacingRight)
        {
            Flip();
        }

    }

    public void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
