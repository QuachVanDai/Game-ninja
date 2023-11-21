using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class monsterAttack :MonoBehaviour
{
    public float radius = 1.0f;
    public LayerMask PlayerMask;
    public LayerMask targetLayer;
    public Transform firePoint;
    public GameObject bulletPrefab;
     GameObject bullet;
    private monsterAttacked MonAttacked;
    // Khi nhấn nút bắn (ví dụ nút space)
    private void Start()
    {
        MonAttacked = GetComponent<monsterAttacked>();
    }

    private void Update()
    {
        findPlayer();
    }
    void Shoot()
    {
        // Tạo ra một đạn từ prefab
       bullet=  Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        CancelInvoke(nameof(Shoot));
    }
   

    public void findPlayer()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0.0f, targetLayer);
        foreach (RaycastHit2D hit in hits)
        {
            // Kiểm tra xem đối tượng va chạm có phải là quái vật hay không
            if (hit.collider.CompareTag("player"))
            {
                if (bullet == null && MonAttacked.ob_mon._hp < MonAttacked.max_hp)
                InvokeRepeating(nameof(Shoot), 2, 1);
                // Xử lý logic khi quái vật bị phát hiện
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
