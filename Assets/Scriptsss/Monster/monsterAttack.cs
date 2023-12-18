
using UnityEngine;

public class monsterAttack :NCKHMonoBehaviour
{
    public float radius = 1.0f;
    public LayerMask targetPlayer;
    public Transform firePoint;
    public GameObject bulletPrefab;
     monsterWeapons bullet;
    private monsterAttacked MonAttacked;
    public monster currMoster;
    // Khi nhấn nút bắn (ví dụ nút space)
    private void Start()
    {
        MonAttacked = GetComponent<monsterAttacked>();
        currMoster = GetComponent<monster>();

    }

    private void Update()
    {
        findPlayer();
    }
    void Shoot()
    {
        // Tạo ra một đạn từ prefab
       GameObject g = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
       bullet = g.GetComponent<monsterWeapons>();
       bullet.Damage = Random.Range(currMoster._setMonster.getDameMonsterDictionary(currMoster._level).Item1, currMoster._setMonster.getDameMonsterDictionary(currMoster._level).Item2);
        CancelInvoke(nameof(Shoot));
    }
    public void findPlayer()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0.0f, targetPlayer);
        foreach (RaycastHit2D hit in hits)
        {
            // Kiểm tra xem đối tượng va chạm có phải là quái vật hay không
            if (hit.collider.CompareTag("player"))
            {
                if (bullet == null && MonAttacked.currMoster._currhp < MonAttacked.currMoster.HP)
                    Invoke(nameof(Shoot), 1.8f);
                // Debug.Log("Quái vật đã bị phát hiện!");
            }
        }
    }
    void OnDrawGizmos()
    {
        // Đặt màu của gizmo
        Gizmos.color = Color.yellow;

        // Vẽ hình tròn tại vị trí của đối tượng với bán kính được thiết lập
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
