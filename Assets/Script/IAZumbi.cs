using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAZumbi : MonoBehaviour
{

    public LayerMask layer;
    public Animator anim;

    private Vector3 velocity;

    public  int vida;

    void Start()
    {
        vida = 200;
    }


    void Update()
    {
        if(vida<=0){
            Morrer();
        }

        Animacoes();
    }

    void Animacoes(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1,layer)){
            anim.SetTrigger("ataque");
            
        }
        else if(Physics.Raycast(transform.position, transform.forward,out hit, 10, layer)){

            transform.position = Vector3.Lerp(transform.position,hit.transform.position,0.2f * Time.deltaTime); 
            transform.LookAt(hit.transform);
            anim.SetBool("run",true);
            
        }
        else{
            anim.SetBool("run",false);
          
        }
    }

    void Morrer(){
        anim.SetTrigger("death");
        Destroy(this.gameObject,4f);
    }
}
