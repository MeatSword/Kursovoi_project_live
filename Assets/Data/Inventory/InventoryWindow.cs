using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    public RectTransform itemPanel;
    private GameObject[] delete;
    
    void Start()
    {
        ReDraw();
    }
    public void ReDraw()
    {
        delete = GameObject.FindGameObjectsWithTag("InventoryItems");
        for (int i = 0; i < delete.Length; i++)
        {
            Destroy(delete[i]);
        }
        for (int i = 0; i < Inventory.Instance.InventoryItems.Count; i++)
        {
           
            var item =Inventory.Instance.InventoryItems[i];
            GameObject icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = item.Icon;
            icon.transform.SetParent(itemPanel.transform, true);
            icon.tag = "InventoryItems";
        }
    }
}