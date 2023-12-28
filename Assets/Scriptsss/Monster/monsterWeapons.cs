using UnityEngine;
public class monsterWeapons : NCKHMonoBehaviour
{
    private GameObject playerObject;
    public monster currMoster;
    public float bulletSpeed = 7f;
    public PlayerAttacked character;
    public float Damage;
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
            character.Attacked((int)Damage);
        }
    }
}
