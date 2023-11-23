using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class CharacterController2D : MonoBehaviour
{
    [Header("Character")]
    [Space]
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    public float runSpeed = 0f;
    public bool m_FacingRight = true;
    public bool onGround;

    private Rigidbody2D m_Rigidbody2D;
    private float moveInput = 0f,jumInput;
    private Vector3 velocity = Vector3.zero;
    private Animator animator;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpForce;


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw(TagScript.Horizontal);
        jumInput = Input.GetAxis(TagScript.Vertical);
       
        if (!isGround() && jumInput == 0 )
        {
            animator.SetBool("IsIdleToDown", true);
        }
        if (moveInput != 0)
            Move((moveInput * runSpeed) * Time.fixedDeltaTime);
        if (isGround())
        {
            animator.SetBool("IsIdleToJump", false);
            animator.SetBool("IsIdleToDown", false);
            if (jumInput>0 && m_Rigidbody2D.velocity.y==0)
            {
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpForce);
                animator.SetBool("IsIdleToJump", true);
                animator.SetBool("IsIdleToDown", true);
            }
                animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }
        animator.SetFloat("Jumping", m_Rigidbody2D.velocity.y);
    }
    public bool isGround()
    {
        return onGround = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
    }
    public void Move(float move)
    {
         Vector3 targetVelocity = new Vector2(move * 25f, m_Rigidbody2D.velocity.y);
         m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
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
