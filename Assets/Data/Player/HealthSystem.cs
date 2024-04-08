using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthSystem : MonoBehaviour
{
    public GameObject panel;
    public Slider slider;
    public Text HealthBar;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            PlayerStatsReal.Instance.HP -= EnemyStatsReal.Instance.damageEye;
            HealthBar.text = ""+PlayerStatsReal.Instance.HP;
            slider.value = PlayerStatsReal.Instance.HP;
        }

        if (PlayerStatsReal.Instance.HP <= 0)
        {
            Death();
        }
    }

    private void Start()
    {
        panel.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Timer.Instance.timeSecNull > 1 && PlayerStatsReal.Instance.HP<100)
        {
            PlayerStatsReal.Instance.HP++;
            HealthBar.text = ""+PlayerStatsReal.Instance.HP;
            slider.value = PlayerStatsReal.Instance.HP;
            Timer.Instance.timeSecNull = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("SkelMageFire"))
        {
            PlayerStatsReal.Instance.HP -= EnemyStatsReal.Instance.damageSkelMage;
            HealthBar.text = ""+PlayerStatsReal.Instance.HP;
            slider.value = PlayerStatsReal.Instance.HP;
            Destroy(col.gameObject);
        }
        if (PlayerStatsReal.Instance.HP <= 0)
        {
            Death();
        }
        
    }

    void Death()
    {
        panel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
