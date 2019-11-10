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
    bool Shield = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        yv = rb.velocity.y;        
        if(Input.GetKey(KeyCode.A)&&!Shield){
            spriteRenderer.flipX = true;
            xv -= 1f;
            animator.SetInteger("Walking State", 1);
        }
        if(Input.GetKey(KeyCode.D) && !Shield)
        {
            spriteRenderer.flipX = false;
            xv += 1f;
            animator.SetInteger("Walking State", 1);
        }
        if(Input.GetKey(KeyCode.W)&&canJump && !Shield)
        {
            yv += 5;
            animator.SetTrigger("Jumping");
            canJump = false;
            animator.SetBool("Shield", false);
        }
        if(Mathf.Abs(xv)<0.3){
            animator.SetInteger("Walking State", 0);
        }
        rb.velocity = new Vector2(xv,yv);
        xv *= 0.85f;
        if (Input.GetKey(KeyCode.O))
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("Attack", 3);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                animator.SetInteger("Attack", 1); 
                xv -= 2f;

            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetInteger("Attack", 2);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                xv += 2f;
                animator.SetInteger("Attack", 1);
            }
            else
            {
                if (spriteRenderer.flipX)
                {
                    xv -= 2f;
                }
                else
                {
                    xv += 2f;
                }
                animator.SetInteger("Attack", 1);
            }
        }
        else if (Input.GetKey(KeyCode.P))
        {
            Shield = true;
            animator.SetBool("Shield", true);
        }
        else
        {
            Shield = false;
            animator.SetBool("Shield", false);
            animator.SetInteger("Attack", 0);
        }
    }
    void OnTriggerStay2D(Collider2D Other){
        canJump = true;
    }
}
