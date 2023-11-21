using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterWeapons : MonoBehaviour
{
    private GameObject playerObject;
    public float bulletSpeed = 5f;

    private void Start()
    {
        playerObject = GameObject.FindWithTag("player");
    }
    private void FixedUpdate()
    {
        //if (bullet != null) return;
        Vector2 direction = (playerObject.transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }
    }

 
   
}
/*// Tính toán thời gian di chuyển theo trục x
float timeToTarget = Vector2.Distance(firePoint.position, target.position) / bulletSpeed;

// Tính toán vận tốc theo trục y để theo hình vòng cung (parabola)
float verticalSpeed = (target.position.y - firePoint.position.y - 0.5f * gravity * Mathf.Pow(timeToTarget, 2)) / timeToTarget;

// Áp dụng vận tốc cho viên đạn

bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * bulletSpeed, verticalSpeed);
Destroy(bullet, timeToTarget);*/