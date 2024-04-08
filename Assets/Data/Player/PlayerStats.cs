using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Player stats", menuName = "Stats/Player Stats", order = 54)]
public class PlayerStats : ScriptableObject
{
    [field: SerializeField]public int Hp { get; private set; }
    [field: SerializeField]public float Speed { get; private set; }
    [field: SerializeField]public int Exp { get; private set; }
}