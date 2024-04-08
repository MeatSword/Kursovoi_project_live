using System;
using System.Collections;
using System.Collections.Generic;
using Data.Enemy;
using TMPro;
using UnityEngine;

public class EnemyStatsReal : MonoBehaviour
{
    public TextMeshProUGUI value;
    public GameObject panel;
    public static EnemyStatsReal Instance;
    
    public EnemyStats Eye, SkelMage;
    
    public float commonEnemySpeed,EnemyMeleeHP,EnemyRangeHP,spawnReload=2f;
    
    public int damageEye,damageSkelMage;

    public BossNecromancer _bossNecromancer = new BossNecromancer();
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        damageEye = Eye.Damage;
        damageSkelMage = SkelMage.Damage;

        commonEnemySpeed = Eye.Speed;
        
        EnemyMeleeHP = Eye.HP;
        EnemyRangeHP = SkelMage.HP;

        _bossNecromancer.distance = 25f;
        _bossNecromancer.hp = 4000f;
        _bossNecromancer.reload = 2f;
        _bossNecromancer.speed = Eye.Speed;
    }

    private void Update()
    {
        if (_bossNecromancer.hp<=0)
        {
            value.text = "Вы победили босса";
            StartCoroutine(Death());
        }
    }
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        panel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
