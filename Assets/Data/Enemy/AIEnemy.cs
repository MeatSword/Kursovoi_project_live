using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;

public abstract class AIEnemy : MonoBehaviour
{
    public SpriteRenderer rend;
    public Animator an;
    public Rigidbody2D rb;

    private Vector2 _direct;
    private bool _on = false;
    
    protected float speed;
    protected GameObject player;
    protected bool _may=true;
    protected int knockback=8;

    // public void Awake()
    // {
    //     
    //     //ff
    // }

    public virtual void Start()
    {
        speed = EnemyStatsReal.Instance.commonEnemySpeed;
        player = GameObject.Find("player");
    }
    void FixedUpdate()
    {
        if (_may)
        {
            Following();
        }
    }

    private void Following()
    {
        
        if (_on == false)
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, speed * 0.1f));
            }
        if (transform.position.x > player.transform.position.x)
        {
            rend.flipX=true;
        }
        else
        {
            rend.flipX=false;  
        }
        
    }


    private void OnCollisionStay2D(Collision2D col)
    {
       StartCoroutine(PushAway(true));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Sword"))
        {
            Debug.Log("KKK");
            StartCoroutine(PushAway(false));
        }
    }
    private IEnumerator PushAway(bool has)
    {
        _on = true;
        if (has)
        {
            an.SetBool("IsAttack", true);
        

        yield return new WaitForSeconds(0.3f);
        
            an.SetBool("IsAttack", false);
        }

        rb.DOMove(rb.position - (player.GetComponent<Rigidbody2D>().position - rb.position).normalized * knockback, 1);

        yield return new WaitForSeconds(1);

        _on = false;

    }
}
    




