using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    float xv;
    public SpriteRenderer spriteRenderer;
    float yv = 0f;
    public bool canJump = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        yv = rb.velocity.y;        
        if(Input.GetKey(KeyCode.A)){
            spriteRenderer.flipX = true;
            xv -= 1f;
            animator.SetInteger("Walking State", 1);
        }
        if(Input.GetKey(KeyCode.D)){
            spriteRenderer.flipX = false;
            xv += 1f;
            animator.SetInteger("Walking State", 1);
        }
        if(Input.GetKey(KeyCode.W)&&canJump){
            yv += 5;
            animator.SetTrigger("Jumping");
            canJump = false;
        }
        if(Mathf.Abs(xv)<0.3){
            animator.SetInteger("Walking State", 0);
        }
        rb.velocity = new Vector2(xv,yv);
        xv *= 0.85f;
        
    }
    void OnTriggerStay2D(Collider2D Other){
        canJump = true;
    }
}
