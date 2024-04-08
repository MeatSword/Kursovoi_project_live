using System.Collections;
using System.Collections.Generic;
using Data.Inventory;
using UnityEngine;

public class StatsWeapon : MonoBehaviour
{
    public static StatsWeapon Instance;
    
    public BulletStats bowSt,swordSt,daggerSt,staffSt;
    public GameObject missileBow,missileSword,missileDagger,missileStaff;

    public SwordStats Sword = new SwordStats();
    public BowStats Bow = new BowStats();
    public DaggerStats Dagger = new DaggerStats();
    public StaffStats Staff = new StaffStats();
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        Bow.firecount = 1;
        Bow.reload = 1f;
        Bow.damage = bowSt.Damage;
        Bow.speed = bowSt.Speed;
        Bow.distance = 25f;

        Sword.reload = 1f;
        Sword.damage= swordSt.Damage;
        Sword.size = 0f;
        Sword.distance = 10f;
        
        Dagger.firecount = 1;
        Dagger.reload = 0.2f;
        Dagger.damage = daggerSt.Damage;
        Dagger.speed = daggerSt.Speed;
        Dagger.distance = 15f;

        Staff.damage = staffSt.Damage;
        Staff.distance = 40f;
        Staff.speed = staffSt.Speed;
        Staff.lifetime = staffSt.LifeTime;
        Staff.reload = 7;
    }

    // Update is called once per frame
    
}
