using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public BulletStats BulletStats;
    private float lifetime;
    
    void Start()
    {
        lifetime = BulletStats.LifeTime;
        StartCoroutine(Remove());
    }
    
    private IEnumerator Remove()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(gameObject);
    }
}
