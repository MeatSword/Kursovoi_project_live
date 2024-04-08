using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RemoveSword : MonoBehaviour
{
    public Animator an;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        StartCoroutine(Remove());
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().position = rb.position;
    }

    private IEnumerator Remove()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
