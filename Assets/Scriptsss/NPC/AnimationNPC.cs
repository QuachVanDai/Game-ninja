
using UnityEngine;
using DG.Tweening;

public class AnimationNPC : MonoBehaviour
{
    public GameObject head, body;
    public float target_position, time;
    // Start is called before the first frame update
    void Start()
    {
        head.transform.DOMoveY(head.transform.position.y + target_position, time).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
        body.transform.DOMoveY(body.transform.position.y + target_position, time).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
