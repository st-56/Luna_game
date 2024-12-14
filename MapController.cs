using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public GameObject mapPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (mapPanel != null)
        {
            mapPanel.SetActive(false); // 遊戲開始時隱藏地圖
        }
        else
        {
            Debug.LogError("MapPanel is not assigned. Please assign it in the Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 偵測按鍵（例如 M 鍵）來顯示/隱藏地圖
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMap();
        }
    }

    void ToggleMap()
    {
        if (mapPanel != null)
        {
            // 切換地圖顯示狀態
            mapPanel.SetActive(!mapPanel.activeSelf);
        }
    }
}
