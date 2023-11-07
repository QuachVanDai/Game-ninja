using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Animation/Frame Animation")]
public class FrameAnimations : ScriptableObject
{
    // animation nhaan vat
    [Header("Idle character")]
    public Sprite[] c_bodyFramesIdle;
    public Sprite[] c_footFramesIdle;
    [Header("Move character")]
    public Sprite[] c_bodyFramesRun;
    public Sprite[] c_footFramesRun;
    [Header("Jump character")]
    public Sprite[] c_bodyFramesJump;
    public Sprite[] c_footFramesJump;
    [Header("Death character")]
    public Sprite[] c_bodyFramesDeath;
    public Sprite[] c_footFramesDeath;
    [Header("Attack character")]
    public Sprite[] c_bodyFramesAttack;
    public Sprite[] c_footFramesAttack;

    // animation quai vat
    [Header("Idle monster")]
    public Sprite[] m_bodyFramesIdle;
    [Header("Move monster")]
    public Sprite[] m_bodyFramesMove;
    [Header("Attack monster")]
    public Sprite[] m_bodyFramesAttack;
    [Header("Death monster")]
    public Sprite[] m_bodyFramesDeath;

}
