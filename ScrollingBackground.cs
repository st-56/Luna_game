using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    //[SerializeField] private float scrollSpeed = 0.1f;
    [SerializeField] private Texture2D backgroundTexture; // 背景圖片
    [SerializeField] private float tilingFactor = 1f;
    private Material material;
    //private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        // 獲取 Renderer 上的材質
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;

        // 設置材質的貼圖
        if (backgroundTexture != null)
        {
            material.mainTexture = backgroundTexture;

            // 獲取圖片的寬高比
            float imageAspect = (float)backgroundTexture.width / backgroundTexture.height;

            // 根據圖片的比例調整物件的 Scale
            transform.localScale = new Vector3(transform.localScale.y * imageAspect, transform.localScale.y, 1);

            // 設置 Tiling，讓圖片重複填滿拉長的寬度
            float tilingX = transform.localScale.x / transform.localScale.y * tilingFactor;
            material.mainTextureScale = new Vector2(tilingX, 1);
        }
        
        //獲取renderer的材質
        //material = GetComponent<Renderer>().material;
        //初始化偏移量
        //offset = Vector2.zero;
        // 獲取物件的 X 軸長度，根據它設置材質 Tiling
        //float scaleX = transform.localScale.x;
        //float scaleY = transform.localScale.y;

        // 設置材質的 Tiling（圖片重複）
        //material.mainTextureScale = new Vector2(scaleX * tilingFactor, scaleY);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        //持續改變材質的偏移量(只有x軸)
        offset.x += scrollSpeed * Time.deltaTime;
        //將偏移量應用到材質的maintextureoffset
        material.mainTextureOffset = offset;
    }
    */
}
