using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float dir = 1;
    int count = 0;
    float timeUpdate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(count<1)
        {
            timeUpdate += Time.time;
            count ++;
        }
        if(timeUpdate > Time.time){
            transform.Translate(new Vector3(dir,0f,0f));
        }
        else{
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name=="BoxerBoi"){
            other.gameObject.GetComponent<ITakeDamage>().damage(0.1f);
        }
        if(other.gameObject.name!="Player"){
            Destroy(gameObject);
        }
    }

}
