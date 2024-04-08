using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Data.Enemy;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HPSystemEnemy : MonoBehaviour
{
    public Animator an;
    public GameObject exp1;
    private bool _IsNotReady;
    private float hp;

    void Start()
    {
        if (this.gameObject.GetComponent<EnemyMelee>())
        {
            hp = EnemyStatsReal.Instance.EnemyMeleeHP;
        }
        if (this.gameObject.GetComponent<EnemyRange>())
        {
            hp = EnemyStatsReal.Instance.EnemyRangeHP;
        }
        if (this.gameObject.GetComponent<EnemyNecromancer>())
        {
            hp = EnemyStatsReal.Instance._bossNecromancer.hp;
        }
        
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {

            hp -= StatsWeapon.Instance.Bow.damage;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Dagger"))
        {

            hp -= StatsWeapon.Instance.Dagger.damage;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Sword"))
        {
            hp -= StatsWeapon.Instance.Sword.damage;
            
        }
        if (col.gameObject.CompareTag("Staff"))
        {
            hp -= StatsWeapon.Instance.Staff.damage;
        }
        if (gameObject.GetComponent<EnemyNecromancer>())
        {
            EnemyStatsReal.Instance._bossNecromancer.hp = hp;
        }
        if (hp <= 0)
        {
            StartCoroutine(Death());

        }

        
        
    }

    private IEnumerator Death()
    {
        an.SetBool("IsDeath", true);
        
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        Destroy(this.gameObject.GetComponent<Collider2D>());
        if (gameObject.GetComponent<EnemyNecromancer>())
        {
            Slider slider= GameObject.Find("BossBar").GetComponent<Slider>();
            Destroy(slider.gameObject);
        }
         
        yield return new WaitForSeconds(1);
        
        Instantiate(exp1, transform.position, quaternion.identity);
        Destroy(gameObject);
    }
    
}
