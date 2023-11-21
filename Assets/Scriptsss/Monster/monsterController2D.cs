using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterController2D : MonoBehaviour
{
    private float stTime;
    private monsterStatus Status;
    public Animator ani;
    public float t;
    [Range(1,3)]
    public float monterSpeed=1;
    public bool m_FacingRight = true;
    private Vector3[] Point;
    private int currentWaypointIndex=0;
    private void Start()
    {
        Status = monsterStatus.idle;
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
            if (Time.time - stTime > t*3)
            {
                stTime = Time.time;
                t=Random.Range(2,4);
            }
               
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
    public void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void PlayAnimation(monsterStatus Status)
    {
       switch (Status)
        {
            case monsterStatus.idle:
                Status = monsterStatus.idle;
                ani.SetBool("isMove", false);
                break;
            case monsterStatus.move:
                Status = monsterStatus.move;
                ani.SetBool("isMove", true);
                monterMove();
                break;
            case monsterStatus.attack:
                Status = monsterStatus.attack; 
                break;
            case monsterStatus.death:
                Status = monsterStatus.death; 
                break;
        }
    }
}
public enum monsterStatus { idle, move, attack, death }