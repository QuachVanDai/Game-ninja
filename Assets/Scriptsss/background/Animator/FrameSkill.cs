using UnityEngine;

[CreateAssetMenu(menuName = "Animations/Frame Skill")]
public class FrameSkill : ScriptableObject
{
    public Sprite[] skillFrames;
    public int mp;
    public float timeSkill;
    public float coefficient;


}
