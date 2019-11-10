using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,ITakeDamage
{
    public Rigidbody2D rb;
    public Animator animator;
    float xv;
    public SpriteRenderer spriteRenderer;
    float yv = 0f;
    bool flipX = false;
    bool canJump = true;
    bool Shield = false;
    public Animator healthBar;
    float nextBullet = 0f;
    int melee = 0;
    float health = 10;
    public GameObject projectileRight;
    float damageUpdate = 0f;
    public GameObject projectileLeft;

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(health);
        yv = rb.velocity.y;        
        if(Input.GetKey(KeyCode.A)&&!Shield){
            flipX = true;
            transform.eulerAngles = new Vector3(0,180,0);
            xv -= 1f;
            animator.SetInteger("Walking State", 1);
        }
        if(Input.GetKey(KeyCode.D) && !Shield)
        {
            flipX = false;
            transform.eulerAngles = new Vector3(0,0,0);
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
                melee = 2;
                animator.SetInteger("Attack", 3);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                melee = 1;
                animator.SetInteger("Attack", 1); 
                xv -= 2f;

            }
            else if (Input.GetKey(KeyCode.S)&&nextBullet<Time.time)
            {
                nextBullet = Time.time + 0.3f;
                animator.SetInteger("Attack", 2);
                Instantiate(projectileRight, transform.position + new Vector3(0.3f,0,0),Quaternion.identity); 
                Instantiate(projectileLeft, transform.position + new Vector3(-1f,0,0),Quaternion.identity); 
            }
            else if (Input.GetKey(KeyCode.D))
            {
                melee = 1;
                xv += 2f;
                animator.SetInteger("Attack", 1);
            }
            else
            {
                if (flipX)
                {
                    xv -= 2f;
                }
                else
                {
                    xv += 2f;
                }
                melee = 1;
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
            melee = 0;
            animator.SetBool("Shield", false);
            animator.SetInteger("Attack", 0);
        }
        
        healthBar.SetFloat("Health", health);
        
        if(transform.position.y<-5f){
            health = health/2;
            transform.position = new Vector3(-3f,2f,0f);
        }
    }
    void OnTriggerStay2D(Collider2D Other){
        if(Other.transform.position.y<(transform.position.y-1.1f))
        {
            canJump = true;
        }
        if(melee > 0&&Other.gameObject.name == "BoxerBoi"&&damageUpdate<Time.time){
            damageUpdate = Time.time + 0.3f; 
            if(melee == 1){
                Other.gameObject.GetComponent<ITakeDamage>().damage(0.5f);
            }
            if(melee == 2){
                Other.gameObject.GetComponent<ITakeDamage>().damage(2);
            }
            
        }
    }
    public void damage(float damage){
        if(!Shield){
            health -= damage;
        }
    }
}
