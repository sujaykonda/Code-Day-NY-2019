using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerAI : MonoBehaviour, ITakeDamage
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
    bool jump = false;
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
            if(Mathf.Abs(Vector3.Distance(Playpos.position,Pos.position))<5f){
                if(Mathf.Abs(Playpos.position.y-Pos.position.y)<1){
                    anim.SetBool("IsUppercutting", true);
                }
                else{
                    anim.SetTrigger("IsJumping");
                    jump = true;
                }

            }
            rb.velocity = new Vector2(xv, yv);
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.name == "Player"){
            other.gameObject.GetComponent<ITakeDamage>().damage(1);
        }
    }
    public void damage(float damage){
        health-= damage;
    }
    
}