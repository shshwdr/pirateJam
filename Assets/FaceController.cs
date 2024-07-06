using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour
{
    public Vector2 angryOffset;
    public Vector2 smileOffset;
    public Material material; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (material != null)
        {
            if(Input.GetKeyDown(KeyCode.Z))
                // 设置材质的纹理偏移
                material.SetTextureOffset("_MainTex", angryOffset);
            if(Input.GetKeyDown(KeyCode.X))
                // 设置材质的纹理偏移
                material.SetTextureOffset("_MainTex", smileOffset);
        }
        else
        {
            Debug.LogError("Material is not assigned.");
        }
    }
}
