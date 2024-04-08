using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveerPlayer : MonoBehaviour
{
    public SpriteRenderer rer;
    public Rigidbody2D rb;
    public Joystick joy;
    private Vector2 move;
    private Vector2 moveVector;

void FixedUpdate()
{
    MovementLogic();
}
private void MovementLogic()
{
    //moveVector.x = Input.GetAxis("Horizontal");
    moveVector.x = joy.Horizontal;
    moveVector.y = joy.Vertical;
    //moveVector.y = Input.GetAxis("Vertical");
    rb.MovePosition(rb.position + moveVector * PlayerStatsReal.Instance.speed * Time.fixedDeltaTime);
    if (moveVector.x < 0)
    {
        rer.flipX = true;
    }
    else
    {
        rer.flipX = false;
    }
    if (moveVector.x == 0 && moveVector.x == 0)
    {
        AnimatorAI.Instance.StayPlayer();
    }
    else
    {
        AnimatorAI.Instance.RunPlayer();
    }
    //rb.MovePosition(rb.position + Vector2.Lerp(rb.transform.position,moveVector,speed));
}
}
