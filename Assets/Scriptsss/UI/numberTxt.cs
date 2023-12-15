using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public  class numberTxt:MonoBehaviour
{
    public numberTxt() { }
   public void aniTextY(TextMeshProUGUI text,Transform parent, Transform transformScale, int number,Vector3 start,float target ,float time,Color color)
    {
       
        TextMeshProUGUI text1 = Instantiate(text);
        text1.transform.parent = parent;
        text1.transform.localScale = transformScale.localScale;
        text1.gameObject.SetActive(true);
        text1.text =  number.ToString();
        text1.rectTransform.anchoredPosition = start;
        text1.color = color;
        var t = text1.rectTransform.DOAnchorPosY(text1.rectTransform.localPosition.y + target, time)
        .OnComplete(() => Destroy(text1.gameObject));
    }

}
