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
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(xv, yv);
        if (Playpos.position.x < Playpos.position.x)
        {
            xv -= 1f;
            if (Playpos.position.y < Playpos.position.y)
            {
                xv -= 1f;
            }
            if (Playpos.position.y > Playpos.position.y)
            {
                yv += 3f;
            }
        }
        if (Playpos.position.x > Playpos.position.x)
        {
            xv += 1f;
            if (Playpos.position.y < Playpos.position.y)
            {
                xv += 1f;
            }
            if (Playpos.position.y > Playpos.position.y)
            {
                yv += 3f;
            }
        }
        if (Playpos.position.x == Playpos.position.x)
        {
            if (Playpos.position.y < Playpos.position.y)
            {
                xv += 1f;
            }
            if (Playpos.position.y > Playpos.position.y)
            {
                yv += 3f;
            }
            if (Playpos.position.y == Playpos.position.y)
            {

            }
        }
    }
}
