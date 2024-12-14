using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxFactor = 0.5f;
    public float movementThreshold = 0.01f;
    private Vector3 lastCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // 自動找到主攝影機
        }

        //初始化攝影機位置
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 計算攝影機移動的距離
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // 如果移動距離小於閾值，則不更新背景
        if (deltaMovement.magnitude > movementThreshold)
        {
            // 背景移動，按比例調整
            transform.position += deltaMovement * parallaxFactor;

            // 更新上一次的攝影機位置
            lastCameraPosition = cameraTransform.position;   
        }
    }
}
