using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<Item> StartItems;
    public ObservableCollection<Item> InventoryItems = new ObservableCollection<Item>();
    public List<Item> AllItems;
    
    void Awake()
    {
        InventoryItems.CollectionChanged += OnAdd;
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        for(int i = 0; i < StartItems.Count; i++)
        {
            InventoryItems.Add(StartItems[i]);
        }
        
    }

    // Update is called once per frame
    public void OnAdd([CanBeNull] object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems?[0] is Item itm)
        {
            if (itm.Name == "Bow")
            {
                this.AddComponent<BowAtt>();
            }
            if (itm.Name == "Staff")
            {
                this.AddComponent<StaffAtt>();
            }
            if (itm.Name == "Dagger")
            {
                this.AddComponent<DaggerAtt>();
            }

            if (itm.Name == "Sword")
            {
                this.AddComponent<SwordAtt>();
            }
        }
    }
}
