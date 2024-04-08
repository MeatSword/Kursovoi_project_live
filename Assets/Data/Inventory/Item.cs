using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Item stats", menuName = "Stats/Item Stats", order = 53)]
public class Item : ScriptableObject
{
    [field: SerializeField]public string Name { get; private set; }
    [field: SerializeField]public Sprite Icon { get; private set; }
    [field: SerializeField]public int ScaleDamage{ get; private set; }
    [field: SerializeField]public string Desc{ get; private set; }
}