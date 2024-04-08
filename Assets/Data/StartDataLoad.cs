using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class StartDataLoad : MonoBehaviour
{
    public Button rz1, rz2;
    void Start()
    {
        Time.timeScale = 1;
        Inventory.Instance.InventoryItems.Add(Inventory.Instance.AllItems[StartData.weaponchoice]);
        
        rz1.gameObject.SetActive(StartData.razrabmode);
        rz2.gameObject.SetActive(StartData.razrabmode);
    }

}
