
using UnityEngine;
using DG.Tweening;

public class extendMenu : MonoBehaviour
{

    [SerializeField] private RectTransform rectTransform;

    [Space]
    [SerializeField] private Vector2 normalStateArea;

    [Space]
    [SerializeField] private Vector2 expandStateArea;

    [SerializeField] private bool isDefaultExpand;

    private bool _isNormal = true;
    Tweener _tweener;

    private void Reset()
    {
        if (TryGetComponent(out rectTransform))
        {
            normalStateArea = rectTransform.sizeDelta;
        }
    }

    private void Start()
    {
        if (isDefaultExpand)
        {
            ToExpandState();
        }
    }

    public void ToNormalState()
    {
        _isNormal = true;
        _tweener?.Kill();
        _tweener = rectTransform.DOSizeDelta(normalStateArea, 0.25f);
    }

    public void ToExpandState()
    {
        _isNormal = false;
        _tweener?.Kill();
        _tweener = rectTransform.DOSizeDelta(expandStateArea, 0.25f);
    }

    public void SwitchState()
    {
        if (_isNormal)
        {
            ToExpandState();
        }
        else
        {
            ToNormalState();
        }
    }
}
