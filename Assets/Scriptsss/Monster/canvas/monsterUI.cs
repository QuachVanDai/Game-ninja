using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class monsterUI : MonoBehaviour
{
    public Transform aniDamaged;
    public TextMeshProUGUI txt_damaged;

    public void damaged()
    {
        Debug.Log(txt_damaged.rectTransform.localPosition.y + " " + txt_damaged.rectTransform.position.y+1);
        var t = txt_damaged.rectTransform.DOAnchorPosY(txt_damaged.rectTransform.localPosition.y + 50, 1.5f);
    }
}
