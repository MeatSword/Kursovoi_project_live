using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SwordAtt : playerAttack
{
    private float distance = StatsWeapon.Instance.Sword.distance;
    void FixedUpdate()
    {
        if (_IsNotReload)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (Vector2.Distance(transform.position, _posEnemy) < distance)
            {
                Attack();
            }
            else
            {
                FindPos();
            }
        }

    }

    void Sword()
    {
        GameObject fire = Instantiate(StatsWeapon.Instance.missileSword, rb.position, quaternion.identity);
        fire.transform.localScale += new Vector3(
            StatsWeapon.Instance.Sword.size,
             StatsWeapon.Instance.Sword.size,0f);
        fire.GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(rb.position,_posEnemy,0));
        
        Vector2 diference =  new Vector2(_posEnemy.x - fire.transform.position.x,_posEnemy.y - fire.transform.position.y);
        float rot_z = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        fire.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    void Attack()
    {
        StartCoroutine(Attacck());
    }
    private IEnumerator Attacck()
    {
        _IsNotReload = false;
        FindPos();
        Sword();
        yield return new WaitForSeconds(StatsWeapon.Instance.Sword.reload);
        _IsNotReload = true;
    }
}
