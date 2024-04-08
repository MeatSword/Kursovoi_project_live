using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public Text[] Lvl;
    public ExpSystem exp;
    public InventoryWindow wind;
    public GameObject panel;
    private bool Has;

    private int l;
    private int[] LvlCount= new int[6];
    void Start()
    {
        LvlCount[0]++;
    }

    public void OnClick1()
    {
        l = 0;
        panel.SetActive(false);
        Time.timeScale = 1;
        Fill(l);
        exp.currentItems.Clear();
        wind.ReDraw();
    }

    public void OnClick2()
    {

        l = 1;
        panel.SetActive(false);
        Time.timeScale = 1;
        Fill(l);
        exp.currentItems.Clear();
        wind.ReDraw();
    }

    public void OnClick3()
    {

        l = 2;
        panel.SetActive(false);
        Time.timeScale = 1;
        Fill(l);
        exp.currentItems.Clear();    
        wind.ReDraw();
    }

    void Fill(int k)
        {
            Debug.Log(exp.currentItems[k]);
            for (int i = 0; i < Inventory.Instance.InventoryItems.Count;i++)
            {
                if (Inventory.Instance.InventoryItems[i] == exp.currentItems[k])
                {
                    Has = true;
                    if (exp.currentItems[k].Name == "Bow")
                    {
                        LvlCount[i]++;
                        Lvl[i].text = "LVL \n" + LvlCount[i];
                        if(exp.text[k].text=="Увеличивает скорость атаки")
                        {
                            if (StatsWeapon.Instance.Bow.reload != 0.2f)
                            {
                                StatsWeapon.Instance.Bow.reload-= 0.1f;
                            }
                        }
                        if(exp.text[k].text=="Увеличивает кол-во снарядов")
                        {
                            StatsWeapon.Instance.Bow.firecount++;
                        }
                        if (exp.text[k].text == "Увеличивает урон")
                        {
                            StatsWeapon.Instance.Bow.damage +=50;
                        }
                            
                    }
                    if (exp.currentItems[k].Name == "Staff")
                    {
                        LvlCount[i]++;
                        Lvl[i].text = "LVL \n" + LvlCount[i];
                        if(exp.text[k].text=="Увеличивает скорость атаки")
                        {
                            if (StatsWeapon.Instance.Staff.reload != 0.2f)
                            {
                                StatsWeapon.Instance.Staff.reload-= 1f;
                            }
                        }
                        if(exp.text[k].text=="Увеличивает время жизни")
                        {
                            StatsWeapon.Instance.Staff.lifetime+=2;
                        }
                        if (exp.text[k].text == "Увеличивает урон")
                        {
                            StatsWeapon.Instance.Staff.damage +=10;
                        }
                            
                    }
                    if (exp.currentItems[k].Name == "Dagger")
                    {
                        LvlCount[i]++;
                        Lvl[i].text = "LVL \n" + LvlCount[i];
                        if(exp.text[k].text=="Увеличивает дистанцию")
                        {
                            StatsWeapon.Instance.Dagger.distance+=5f;
                        }
                        if(exp.text[k].text=="Увеличивает кол-во снарядов")
                        {
                            StatsWeapon.Instance.Dagger.firecount++;
                        }
                        if (exp.text[k].text == "Увеличивает урон")
                        {
                            StatsWeapon.Instance.Dagger.damage +=10;
                        }
                            
                    }
                    if (exp.currentItems[k].Name == "Sword")
                    {
                        LvlCount[i]++;
                        Lvl[i].text = "LVL \n" + LvlCount[i];
                        if(exp.text[k].text=="Увеличивает скорость атаки")
                        {
                            if (StatsWeapon.Instance.Sword.reload != 0.2f)
                            {
                                StatsWeapon.Instance.Sword.reload -= 0.1f;
                            }
                        }
                        if(exp.text[k].text=="Увеличивает дистанцию")
                        {
                            StatsWeapon.Instance.Sword.size+=5f;
                            StatsWeapon.Instance.Sword.distance+=2.5f;
                        }
                        if (exp.text[k].text == "Увеличивает урон")
                        {
                            StatsWeapon.Instance.Sword.damage +=50;
                        }
                            
                    }
                }
            }
            if (!Has)
            {
                Inventory.Instance.InventoryItems.Add(exp.currentItems[k]);
                LvlCount[Inventory.Instance.InventoryItems.Count - 1]++;
                Lvl[Inventory.Instance.InventoryItems.Count-1].text = "LVL \n" +LvlCount[Inventory.Instance.InventoryItems.Count-1];
                
            }
            Has = false;
        }
    }

