
using Unity.Mathematics;
using UnityEngine;

public class CAMERAMOVE : MonoBehaviour
{
    private Transform player;
    public float xMax, yMax, xMin, yMin;
    private string playerTag = "player";
    private float getX, x;
    private float getY, y;
    // Update is called once per frame
    private void Start()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Không tìm thấy đối tượng có tag là Player.");
        }
    }
    private void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        x = math.max(xMin, player.position.x);
        getX = math.min(xMax, x);
        /*  TH1:       Nếu player ơ vị trí nhỏ hơn -6;
                vd player.positon.x =-7 ==> X_min=-6; ==> getX = -6 

           TH2:     Nếu player ở vị trí lớn hơn 6 :
                vd player.positon.x = 7 ==> X_min= 7 ; ==> getX = 6;

        Muc dich cho toa do X cua Camera  nằm trong khoảng (-6, 6)
        */
        y = math.max(yMin, player.position.y);
        getY = math.min(yMax, y);
        transform.position = new Vector3(getX, getY, transform.position.z);
    }
}
    /*private bool isDragging = false;
    private Vector3 previousMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            previousMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 deltaMousePosition = Input.mousePosition - previousMousePosition;
            Vector3 newPosition = transform.position - deltaMousePosition * 0.02f;
    *//*        if (newPosition.y < 0)
            {
                newPosition.y = 0;
            }
            else if (newPosition.y > 3)
            {
                newPosition.y = 3;
            }
            if (newPosition.x <= -1)
            {
                newPosition.x = -1;

            }
            else if (newPosition.x >= 27)
            {
                newPosition.x = 27;
            }*//*
            transform.position = newPosition;
        }

        previousMousePosition = Input.mousePosition;
    }
}
*/