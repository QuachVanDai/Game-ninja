using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class numberTxt:NCKHMonoBehaviour
{
    public TextMeshProUGUI text;
 /*  public void aniTextY(TextMeshProUGUI text,RectTransform parent, Transform transformScale, int number,Vector3 start,float target ,float time,Color color)
    {
       
        TextMeshProUGUI text1 = Instantiate(text);
        text1.rectTransform.parent = parent;
        text1.rectTransform.localScale = transformScale.localScale;
        text1.gameObject.SetActive(true);
        text1.text =  number.ToString();
        text1.rectTransform.anchoredPosition = start;
        text1.color = color;
        var t = text1.rectTransform.DOAnchorPosY(text1.rectTransform.localPosition.y + target, time)
        .OnComplete(() => Destroy(text1.gameObject));
    }*/
    public void aniTextY1(RectTransform parent, int number, Vector3 start, float target, float time, Color color)
    {

        text.rectTransform.SetParent(parent.transform,false);
      //  text.transform.localScale = transformScale.localScale;
        text.gameObject.SetActive(true);
        text.text = number.ToString();
        text.rectTransform.anchoredPosition = start;
        text.color = color;
        var t = text.rectTransform.DOAnchorPosY(text.rectTransform.localPosition.y + target, time)
        .OnComplete(() => Destroy(text.gameObject));
    }
}
