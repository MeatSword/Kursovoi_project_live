using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy stats", menuName = "Stats/Enemy Stats", order = 52)]
public class EnemyStats: ScriptableObject
{
    [field: SerializeField]public int HP{ get; private set; }
    [field: SerializeField]public float Speed { get; private set; }
    [field: SerializeField]public int Damage { get; private set; }
    
    
}