
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class SkillAnimation : MonoBehaviour
{
    SpriteRenderer skillSprite;
    Vector2 positionStart;
    public Transform target;
    void Awake()
    {
        positionStart = transform.localPosition;
        skillSprite = GetComponent<SpriteRenderer>();
    }
    public void AnimationSkill(FrameSkill _frameSkill)
    {
        gameObject.SetActive(true);
        StartCoroutine(AnimatorFrame.FrameGame(skillSprite, _frameSkill.skillFrames, true, null, 0.05f));
        MoveSkill();
    }
    public void AnimationSkillLv5_15(FrameSkill _frameSkill)
    {
        gameObject.SetActive(true);
        transform.localPosition = positionStart;
        StartCoroutine(AnimatorFrame.FrameGame(skillSprite, _frameSkill.skillFrames, true, null, 0.05f));
        StartCoroutine(SkillLv5_15());
    }
    void MoveSkill()
    {
        transform.DOKill();
        transform.localPosition = positionStart;
        var t = transform.DOMoveX(target.position.x, 0.5f).OnComplete(()=> gameObject.SetActive(false));
    }
    IEnumerator SkillLv5_15()
    {
        yield return new WaitForSeconds(1.25f);
        gameObject.SetActive(false);
    }
  
}
