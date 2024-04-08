using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BowAtt : playerAttack
{
    private float distance = StatsWeapon.Instance.Bow.distance;
    void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (Vector2.Distance(transform.position, _posEnemy) < distance)
        {
            if (_IsNotReload)
            {
                Attack();
            }
        }
        else
        {
            FindPos();
        }

    }
    void Bow()
    {
        for (int i = 0; i < StatsWeapon.Instance.Bow.firecount; i++)
        {
            GameObject fire = Instantiate(StatsWeapon.Instance.missileBow, transform.position, quaternion.identity);
            
            Vector2 diference =  new Vector2(_posEnemy.x - fire.transform.position.x,_posEnemy.y - fire.transform.position.y);
            float rot_z = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            fire.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            
            if (i == 0)
            {
                fire.GetComponent<Rigidbody2D>()
                    .AddForce(rb.position + (_posEnemy - rb.position).normalized *
                        StatsWeapon.Instance.Bow.speed * 1000);
            }
            if (i % 2 == 0)
            {
                fire.GetComponent<Rigidbody2D>()
                    .AddForce(rb.position + (_posEnemy - (rb.position - new Vector2(i, i))).normalized *
                        StatsWeapon.Instance.Bow.speed * 1000);
            }
            else if(i%2!=0)
            {
                fire.GetComponent<Rigidbody2D>()
                    .AddForce(rb.position + (_posEnemy - (rb.position + new Vector2(i, i))).normalized *
                        StatsWeapon.Instance.Bow.speed * 1000);
            }
        }
        
    }
    void Attack()
    {
        StartCoroutine(Attacck());
    }
    private IEnumerator Attacck()
    {
        _IsNotReload = false;
        FindPos();
        Bow();
        yield return new WaitForSeconds(StatsWeapon.Instance.Bow.reload);
        _IsNotReload = true;
    }
}
