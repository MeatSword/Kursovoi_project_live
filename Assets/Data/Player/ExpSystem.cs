using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;
using Slider = UnityEngine.UI.Slider;

public class ExpSystem : MonoBehaviour
{
    public List<Item> currentItems;
    public Text[] text;
    public GameObject panel;
    public RectTransform itemPanel;
    public Slider slider;
    public string[] BuffWeaponBow={"Увеличивает скорость атаки","Увеличивает кол-во снарядов","Увеличивает урон"};
    public string[] BuffWeaponStaff={"Увеличивает время жизни","Увеличивает урон","Увеличивает скорость атаки"};
    public string[] BuffWeaponSword={"Увеличивает скорость атаки","Увеличивает дистаницю","Увеличивает урон"};
    public string[] BuffWeaponDagger={"Увеличивает дистанцию","Увеличивает кол-во снарядов","Увеличивает урон"};
    private int exp,lvl;
    private bool Is;
    void Start()
    {
        panel.SetActive(false);
    }

    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Exp1"))
        {
            Destroy(col.gameObject);
            exp += PlayerStatsReal.Instance.EXP;
            slider.value = exp;
            if (exp >= 100 + lvl * 10)
            {
                lvl++;
                exp -= 100 + lvl * 10;
                slider.maxValue += lvl * 10;
                slider.value = exp;
                ChoiceFill();
            }
        }
    }
    public void ChoiceFill()
    {
        string name = "";
        Time.timeScale = 0;
        panel.SetActive(true);
        ClearChoice();
        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, Inventory.Instance.AllItems.Count);
            var item = Inventory.Instance.AllItems[rand];
            if (name != item.Name )
            {
                name = item.Name;
                GameObject icon = new GameObject("Choice");
                icon.AddComponent<Image>().sprite = item.Icon;
                icon.transform.SetParent(itemPanel.transform, true);
                icon.tag = "Choice";
                currentItems.Add(item);
                CheckIs(item);
                if (Is)
                {
                    if (item.name=="Bow")
                    {
                        int rand1 = Random.Range(0, 3);
                        text[i].text = BuffWeaponBow[rand1];
                    }
                    if (item.name=="Staff")
                    {
                        int rand1 = Random.Range(0, 3);
                        text[i].text = BuffWeaponStaff[rand1];
                    }
                    if (item.name=="Dagger")
                    {
                        int rand1 = Random.Range(0, 3);
                        text[i].text = BuffWeaponDagger[rand1];
                    }
                    if (item.name == "Sword")
                    {
                        int rand1 = Random.Range(0, 3);
                        text[i].text = BuffWeaponSword[rand1];
                    }
                }
                else
                {
                    text[i].text = item.Desc;
                }
                Is = false; 
            }
            else
            {
                i--;
            }
        }
        
    }

    void CheckIs(Item item)
    {
        for (int i = 0; i < Inventory.Instance.InventoryItems.Count; i++)
        {
            if (Inventory.Instance.InventoryItems[i] == item)
            {
                Is = true;
            }
        }
    }

    void ClearChoice()
    {
        GameObject[] shop;
        shop=GameObject.FindGameObjectsWithTag("Choice");
        for (int i = 0; i < shop.Length; i++)
        {
            Destroy(shop[i]);
        }
    }
    
    
}
