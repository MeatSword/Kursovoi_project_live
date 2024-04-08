using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRange : AIEnemy
{
    public GameObject bullet;

    private bool reload;
    private float dist;
    private float range=30;
    private void Update()
    {
        if (an.GetBool("IsDeath") == false)
        {
            if (reload == false)
            {
                dist = Vector2.Distance(transform.position, player.transform.position);
            }
            
            if (dist > range)
            {
                an.SetBool("IsAttack", false);
                _may = true;
            }
            else
            {
                if (reload == false)
                {
                    StartCoroutine(Attack());
                }
                _may = false;
            }
        }
    }

    IEnumerator Attack()
    {
        reload = true;
        an.SetBool("IsAttack",true);
        
        yield return new WaitForSeconds(an.GetCurrentAnimatorClipInfo(0).Length);
        if (an.GetBool("IsDeath") == false)
        {
            Atack();
        }

        reload = false;
    }

    void Atack()
    {
        GameObject fire = Instantiate(bullet, transform.position, quaternion.identity);
        
        Vector2 diference =  new Vector2(player.transform.position.x - fire.transform.position.x,player.transform.position.y - fire.transform.position.y);
        float rot_z = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        fire.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        
        fire.GetComponent<Rigidbody2D>()
            .AddForce(transform.position + (player.transform.position - transform.position).normalized *
                1.5f * 1000);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        
    }
}
