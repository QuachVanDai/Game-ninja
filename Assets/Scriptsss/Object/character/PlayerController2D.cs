using UnityEngine;

public  class PlayerController2D:NCKHMonoBehaviour
{
    private static PlayerController2D instance;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Animator animator;

    public static PlayerController2D Instance { get => instance; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void Awake()
    {
        base.Awake();
        if(PlayerController2D.instance != null) { Debug.LogError("chi cho phep 1 PlayerController2D"); }
        PlayerController2D.instance = this;
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
    public bool getInputE()
    {
        return Input.GetKeyUp(KeyCode.E);
    }
    public bool getInputR()
    {
        return Input.GetKeyUp(KeyCode.R);
    }
}
