using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    float xv;
    float yv = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            xv -= 1f;
            animator.SetInteger("Walking State", 1);
        }
        if(Input.GetKey(KeyCode.D)){
            xv += 1f;
            animator.SetInteger("Walking State", 1);
        }
        if(Input.GetKey(KeyCode.W)){
            animator.SetBool("Jumping", true);
        }
        rb.velocity = new Vector2(xv, yv);
        xv *= 0.85f;
        
    }
}
