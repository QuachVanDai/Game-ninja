using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextTemplate : NCKHMonoBehaviour

{
    private static TextTemplate instance;
    public TextMeshProUGUI textMeshPro;
    public bool Flat = true;
    public string txt;
    public GameObject panel;
    public static TextTemplate Instance { get { return instance; } }    
    
    protected override void Awake()
    {
        base.Awake();
        panel.SetActive(true);
        panel.SetActive(false);
        TextTemplate.instance = this;
    }
    void Start()
    {
        Flat = true;
        //  SetText("Your long text goes here...");
    }
 
    public void SetText(string text)
    {
        if (Flat)
        {
            textMeshPro.text = text;
            panel.SetActive(true);
            // Lấy chiều dài của văn bản
            float textWidth = textMeshPro.preferredWidth;
            // Tạo hiệu ứng di chuyển từ phải sang trái với DOTween
            textMeshPro.rectTransform.DOAnchorPosX(-210, 0.6f).SetEase(Ease.Linear).
                OnComplete(() => StartCoroutine(ClosePanel()));
            Flat = false;
        }
    }
    IEnumerator ClosePanel()
    {
        yield return new WaitForSeconds(1);
        Flat = true;
        textMeshPro.rectTransform.anchoredPosition = new Vector2(210,0);
        panel.SetActive(false);
    }
}
