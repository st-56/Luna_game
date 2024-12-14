using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 主角的 Transform
    public Vector3 offset = new Vector3(0, 0, -10); // 攝影機的偏移量
    public float smoothSpeed = 0.125f; // 平滑跟隨的速度

    // 限制攝影機的移動範圍
    public Vector2 minBounds; // 最小邊界 (X, Y)
    public Vector2 maxBounds; // 最大邊界 (X, Y)

    void Start()
    {
        // 如果 target 未設置，嘗試自動尋找主角
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform; // 自動找到主角的 Transform
            }
            else
            {
                Debug.LogError("Player tag not found! Make sure your player GameObject has the 'Player' tag.");
            }
        }

        // 獲取背景物件並計算邊界範圍
        GameObject backgroundObject = GameObject.Find("Forest"); // 假設背景名稱是 "Forest"
        if (backgroundObject != null)
        {
            MeshRenderer background = backgroundObject.GetComponent<MeshRenderer>();

            if (background != null)
            {
                // 計算背景邊界
                float backgroundWidth = background.bounds.size.x;
                float backgroundHeight = background.bounds.size.z; // MeshRenderer 的高度通常沿 Z 軸

                // 計算攝影機可視範圍
                Camera cam = Camera.main;
                float camHeight = cam.orthographicSize;
                float camWidth = cam.aspect * camHeight;

                // 設定邊界範圍
                minBounds = new Vector2(-backgroundWidth / 2 + camWidth, -backgroundHeight / 2 + camHeight);
                maxBounds = new Vector2(backgroundWidth / 2 - camWidth, backgroundHeight / 2 - camHeight);
            }
            else
            {
                Debug.LogError("MeshRenderer not found on the Background object.");
            }
        }
        else
        {
            Debug.LogError("Background object 'Forest' not found! Please check the object name.");
        }
    }

        void LateUpdate()
        {
            if (target != null)
            {
                // 計算攝影機的目標位置
                Vector3 desiredPosition = target.position + offset;

                // 限制攝影機的位置範圍
                float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
                float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

                // 平滑過渡到限制後的位置
                Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

                transform.position = smoothedPosition;
            }
        }
}
