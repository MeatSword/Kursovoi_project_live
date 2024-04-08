using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public abstract class playerAttack : MonoBehaviour
{
    protected Vector2 _posEnemy;
    protected Rigidbody2D rb;
    protected GameObject[] enemies;
    protected bool _IsNotReload=true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    protected void FindPos()
    {
        _posEnemy = new Vector2(999,999);
        foreach (var enemy in enemies)
        {
            if (enemy.GetComponent<Rigidbody2D>().simulated)
            {
                if (Vector2.Distance(transform.position, _posEnemy) >
                    Vector2.Distance(transform.position, enemy.transform.position))
                {
                    _posEnemy = enemy.transform.position;
                }
            }

        }
    }
   
}



