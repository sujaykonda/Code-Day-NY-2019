using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerAI : MonoBehaviour
{
    public Transform Playpos;
    public Transform Pos;
    public Rigidbody2D rb;
    public float health = 10;
    public Animator anim;
    float xv;
    float yv = 0f;
    public float TimeTilNextUpdate = 0.2f;
    float TimeToUpdate = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
       
        if(Time.time>TimeToUpdate){
            TimeToUpdate = TimeTilNextUpdate + Time.time;
            yv = rb.velocity.y;
            xv *= 0.65f;
            if (Playpos.position.x < Pos.position.x)
            {
                xv -= 1f;
                transform.eulerAngles = new Vector3(0, 180, 0);
                anim.SetBool("IsWalking", true);
            }
            if (Playpos.position.x > Pos.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                xv += 1f;
                anim.SetBool("IsWalking", true);
            }
            if (Playpos.position.x == Playpos.position.x)
            {
            }
            rb.velocity = new Vector2(xv, yv);

        }

    }
}