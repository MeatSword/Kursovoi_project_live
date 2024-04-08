using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Bullet stats", menuName = "Stats/Bullet Stats", order = 51)]
public class BulletStats : ScriptableObject
{
    [field: SerializeField]public float LifeTime { get; private set; }
    [field: SerializeField]public int Damage { get; private set; }
    [field: SerializeField]public float Speed { get; private set; }
}