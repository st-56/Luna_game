using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackController : MonoBehaviour
{
    public GameObject backpackPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (backpackPanel != null)
        {
            backpackPanel.SetActive(false); // 遊戲開始時隱藏背包
        }
        else
        {
            Debug.LogError("BackpackPanel is not assigned. Please assign it in the Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 偵測按鍵（例如 B 鍵）來顯示/隱藏背包
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleBackpack();
        }
    }

    void ToggleBackpack()
    {
        if (backpackPanel != null)
        {
            // 切換背包顯示狀態
            backpackPanel.SetActive(!backpackPanel.activeSelf);
        }
    }
}
