using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    float xv;
    float yv = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            xv -= 1f;
        }
        if(Input.GetKey(KeyCode.D)){
            xv += 1f;
        }
        if(Input.GetKey(KeyCode.W)){
            yv = 5;
        }
        rb.velocity = new Vector2(xv, yv);
        xv *= 0.85f;
        
    }
}
