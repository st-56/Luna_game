using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.1f;
    [SerializeField] bool isHorizontal = true;
    [SerializeField] Renderer rend;
    [SerializeField] Transform playerTransform;
    private Vector3 lastPlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (rend == null)
        {
            rend = GetComponent<Renderer>();
        }

        // 初始化主角位置
        if (playerTransform != null)
        {
            lastPlayerPosition = playerTransform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {  
        // 確保主角 Transform 存在
        if (playerTransform == null) return;

        // 計算主角的移動距離
        Vector3 deltaMovement = playerTransform.position - lastPlayerPosition;

       float offset = isHorizontal ? deltaMovement.x * scrollSpeed : deltaMovement.y * scrollSpeed;

       Vector2 currentOffset = rend.material.mainTextureOffset;
        rend.material.mainTextureOffset = isHorizontal
            ? new Vector2(currentOffset.x + offset, currentOffset.y)
            : new Vector2(currentOffset.x, currentOffset.y + offset);

       // 更新主角的上一次位置
        lastPlayerPosition = playerTransform.position;
    }
}
