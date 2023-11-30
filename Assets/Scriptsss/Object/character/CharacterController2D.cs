using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;
public  class CharacterController2D:MonoBehaviour
{
    private static CharacterController2D instance;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Animator animator;

    public static CharacterController2D Instance { get => instance; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }
    public Animator Animator
    {
        get { return this.animator; }
        set { this.animator = value; }
    }
    public bool isGround()
    {
        return  Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
    }
    public float getInputHorizontal()
    {
        return Input.GetAxisRaw(TagScript.Horizontal);
    }
    public float getInputVertical()
    {
        return Input.GetAxisRaw(TagScript.Vertical);
    }
    public bool getInputSpace()
    {
        return Input.GetKeyUp(KeyCode.Space);
    }
}
