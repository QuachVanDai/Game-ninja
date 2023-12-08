
using UnityEngine;

public class mosterMove : MonoBehaviour
{
    private monsterController2D monsterController2D;
    private float getTime;
    public float t;
    private void Start()
    {
        monsterController2D = GetComponent<monsterController2D>();
        getTime = Time.time;
    }
    private void Update()
    {
        if (Time.time - getTime <= t)
        {
            monsterController2D.PlayAnimation(monsterStatus.idle);
        }
        else
        {
            monsterController2D.PlayAnimation(monsterStatus.move);
            if (Time.time - getTime > t * 3)
            {
                getTime = Time.time;
                t = Random.Range(2, 4);
            }

        }
    }
   
}
