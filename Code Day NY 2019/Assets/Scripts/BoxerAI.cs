using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerAI : MonoBehaviour, ITakeDamage
{
    public Transform Playpos;
    public Transform Pos;
    public Rigidbody2D rb;
    float health = 10;
    public Animator healthBar;
    public Animator anim;
    
    public GameObject winScreen;
    public GameObject loseScreen;
    float xv;
    float yv = 0f;
    public float TimeTilNextUpdate = 0.2f;
    float TimeToUpdate = 0;
    float timeDamage = 0f;
    bool jump = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        winScreen.SetActive(false);
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
            if(Mathf.Abs(Vector3.Distance(Playpos.position,Pos.position))<2f){
                if(Mathf.Abs(Playpos.position.y-Pos.position.y)<1){
                    anim.SetBool("IsUppercutting", true);
                }
                else{
                    anim.SetTrigger("IsJumping");
                    jump = true;
                    anim.SetBool("IsUppercutting", false);
                }

            }
            rb.velocity = new Vector2(xv, yv);
        }
        if(transform.position.y<-5f){
            health = health/2;
            transform.position = new Vector3(3f,3f,0f);
        }
        healthBar.SetFloat("Health",health);
        if(health<=0  && loseScreen.activeSelf == false){
            winScreen.SetActive(true);
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.name == "Player" && Time.time>timeDamage){
            other.gameObject.GetComponent<ITakeDamage>().damage(1);
            timeDamage = Time.time + 0.3f;
        }
    }
    public void damage(float damage){
        health-= damage;
    }
    
}