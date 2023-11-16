using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterManage : MonoBehaviour
{
    private float stTime;
    private monsterStatus m_Status;
    public Animator ani;
    public float t;
    [Range(1,3)]
    public float monterSpeed=1;
    private Vector3[] Point;
    private int currentWaypointIndex=0;
    private void Start()
    {
        m_Status = monsterStatus.idle;
        Point = new Vector3[3];
        ani = GetComponent<Animator>();
        Point[0]=transform.position;
        Point[0].x=transform.position.x + 1;
        Point[1]=transform.position;
        Point[1].x = transform.position.x - 1;
        stTime = Time.time;
    }
    private void Update()
    {
    
        if (Time.time - stTime <= t)
        {
            PlayAnimation(monsterStatus.idle);
        }
        else 
        {
            PlayAnimation(monsterStatus.move);
            if (Time.time - stTime > t*5)
                stTime = Time.time;
        }
    }
    public void monterMove()
    {
      
        if (Vector2.Distance(Point[currentWaypointIndex], transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= 2)
            {
                currentWaypointIndex = 0;
                
            }
            Flip();
        }
        transform.position = Vector2.MoveTowards(transform.position, Point[currentWaypointIndex], Time.deltaTime * monterSpeed);
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void PlayAnimation(monsterStatus Status)
    {
       switch (Status)
        {
            case monsterStatus.idle:
                m_Status = monsterStatus.idle;
                ani.SetBool("isMove", false);
                break;
            case monsterStatus.move:
                m_Status = monsterStatus.move;
                ani.SetBool("isMove", true);
                monterMove();
                break;
            case monsterStatus.attack:
                m_Status = monsterStatus.attack; 
                break;
            case monsterStatus.death:
                m_Status = monsterStatus.death; 
                break;
        }
    }
}
public enum monsterStatus { idle, move, attack, death }