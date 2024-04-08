using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class StaffAtt : playerAttack
{
    private float distance = StatsWeapon.Instance.Staff.distance;
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
    void Staff()
    {
        GameObject fire = Instantiate(StatsWeapon.Instance.missileStaff, new Vector3(transform.position.x,transform.position.y,-3), quaternion.identity);
        
        Vector2 diference =  new Vector2(_posEnemy.x - fire.transform.position.x,_posEnemy.y - fire.transform.position.y);
        float rot_z = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        fire.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            
        fire.GetComponent<Rigidbody2D>()
            .AddForce(rb.position + (_posEnemy - rb.position).normalized *
                StatsWeapon.Instance.Staff.speed * 1000);    
    }
        
    
    void Attack()
    {
        StartCoroutine(Attacck());
    }
    private IEnumerator Attacck()
    {
        _IsNotReload = false;
        FindPos();
        Staff();
        yield return new WaitForSeconds(StatsWeapon.Instance.Staff.reload);
        _IsNotReload = true;
    }
}
