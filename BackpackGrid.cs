using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackGrid : MonoBehaviour
{
    public GameObject backpackGrid;

    // Start is called before the first frame update
    void Start()
    {
        if (backpackGrid != null)
        {
            backpackGrid.SetActive(false); // 遊戲開始時隱藏背包格線
        }
        else
        {
            Debug.LogError("BackpackGrid is not assigned. Please assign it in the Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 偵測按鍵（例如 B 鍵）來顯示/隱藏背包格線
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleBackpackGrid();
        }
    }

    void ToggleBackpackGrid()
    {
        if (backpackGrid != null)
        {
            // 切換背包格線顯示狀態
            backpackGrid.SetActive(!backpackGrid.activeSelf);
        }
    }
}
