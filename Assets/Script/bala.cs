using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    Vector3 velocity;

    float speed = 40;

    // Update is called once per frame
    void Update()
    {
        transform.position+=velocity*Time.deltaTime;
    }

    public void SetDirection(Vector3 direction){
        velocity = direction*speed;
    }

    private void OnCollisionEnter(Collision collision){
        
            
            if(collision.gameObject.tag == "Zumbi"){
                collision.gameObject.GetComponent<IAZumbi>().vida -= 50;
                collision.gameObject.GetComponent<IAZumbi>().anim.SetTrigger("hit");
            }

        Destroy(this.gameObject);
    }
}
