using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [Header("Para exportar")]
    public Animator anim;
    public AudioSource source,reload;
    public Transform player, posBala;
    public GameObject bala;
    public Text txt1,txt2;
    public Camera fpscam;

    private int municaoTotal =100,municaoAtual,pente = 15;
    float vel;

  

    void Start()
    {
        municaoAtual = pente;
        vel = 4;

        AtualizarTexto();
        Cursor.lockState = CursorLockMode.Locked;
    }

  
    void Update()
    {
        Movimentacao();
        Tiro();

    }

    void Movimentacao(){
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        player.transform.Translate(new Vector3(x*vel*Time.deltaTime,0,y*vel*Time.deltaTime));
    }

    void Tiro(){

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(municaoAtual > 0 && municaoTotal > 0){
                Atirar();
                IntanciarBala();
            }
            else if(municaoTotal>0 && municaoAtual==0){
                Recarregar();
            }
        }

            
         if(Input.GetKeyUp(KeyCode.Mouse0)){
            anim.SetBool("tiro",false);
        }

        //recarregar arma
        if(Input.GetKeyDown(KeyCode.R) && municaoAtual!=pente){
            Recarregar();
        }

        
    }

    void Atirar(){
        anim.SetBool("tiro",true);
        municaoAtual--; 
        AtualizarTexto();
        
        source.Play();
    }

    void IntanciarBala(){
        GameObject balaObj = Instantiate(bala, posBala.transform.position, posBala.transform.rotation);
        Destroy(balaObj.gameObject, 5f);

        balaObj.GetComponent<bala>().SetDirection(fpscam.transform.forward);
        
    }


    void Recarregar(){

        municaoTotal -= (pente-municaoAtual);
        municaoAtual = pente;
        anim.SetTrigger("recarregar");
        
    }

    void SomRecarregar(){
        reload.Play();
    }

    void AtualizarTexto(){
        txt1.text = municaoTotal.ToString();
        txt2.text = municaoAtual.ToString();
    }
}
