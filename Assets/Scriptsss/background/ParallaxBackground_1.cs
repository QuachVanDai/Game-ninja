using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground_1 : MonoBehaviour
{
   
    public GameObject prefabsLayers;
    public Transform parentTranform;
    [Range(-5,5)]
    public float LayerSpeed;
    private GameObject Layer;
    private List<GameObject> lstLayers;
    private float flat = 1;
    // Start is called before the first frame update
    void Start()
    {
            lstLayers = new List<GameObject>();
        if(LayerSpeed > 0)
        {
            flat = -1;
        }
            for (int i = 0; i < 3; i++)
            {
                Layer = Instantiate(prefabsLayers, new Vector3(36 * i * flat, 0, 0), Quaternion.identity);
                Layer.transform.parent = parentTranform;
                lstLayers.Add(Layer);
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (lstLayers[0].transform.position.x <= -36 && LayerSpeed < 0)
        {
            Destroy(lstLayers[0]);
            lstLayers.RemoveAt(0);
            Layer = Instantiate(prefabsLayers, new Vector3(lstLayers[1].transform.position.x + 36, 0, 0), Quaternion.identity);
            Layer.transform.parent = parentTranform;
            lstLayers.Add(Layer);
        }
         if (lstLayers[0].transform.position.x >= 72 && LayerSpeed > 0)
        {
            Destroy(lstLayers[0]);
            lstLayers.RemoveAt(0);
            Layer = Instantiate(prefabsLayers, new Vector3(lstLayers[1].transform.position.x - 36, 0, 0), Quaternion.identity);
            Layer.transform.parent = parentTranform;
            lstLayers.Add(Layer);
        }
        lstLayers[0].transform.position += Vector3.right * Time.deltaTime * LayerSpeed;
        lstLayers[1].transform.position += Vector3.right * Time.deltaTime * LayerSpeed;
        lstLayers[2].transform.position += Vector3.right * Time.deltaTime * LayerSpeed;
    }
}
