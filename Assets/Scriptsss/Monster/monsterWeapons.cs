
using UnityEngine;

public class monsterWeapons : MonoBehaviour
{
    private GameObject playerObject;
    public monster currMoster;
    public float bulletSpeed = 7f;
    public PlayerAttacked character;
    private void Start()
    {
        playerObject = GameObject.FindWithTag("player");
        character = FindAnyObjectByType<PlayerAttacked>();
        currMoster = GetComponent<monster>();
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
           /* Debug.Log(currMoster._level);
            int damage = Random.Range(currMoster._setMonster.getDameMonsterDictionary(currMoster._level).Item1, currMoster._setMonster.getDameMonsterDictionary(currMoster._level).Item2);
            character.Attacked(damage);*/
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