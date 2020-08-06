using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    private bool isBlowing;
    private Rigidbody2D rig;
    private Animator anim;
    void Start()
    {
       rig = GetComponent<Rigidbody2D>(); 
       anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move() {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //Movimenta no eixo X
        //transform.position += movement * Time.deltaTime * Speed; //move o personagem mudando a posição dele, sem usar fisicas
        
        float movement = Input.GetAxis("Horizontal"); //Atribui a variavel a movimentação no eixo x
        
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y); //movimenta o personagem usando física

        if(movement > 0f){ //Testa o valor da variável do animator
            anim.SetBool("walk", true); 
            transform.eulerAngles = new Vector3(0f, 0f, 0f); //rotação do personagem quando vira pra direita
        }

        if(movement < 0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f); //rotação do personagem quando vira pra esquerda
        }

        if(movement == 0f){
            anim.SetBool("walk", false);
        }
    }

    void Jump() {
        if (Input.GetButtonDown("Jump") && !isBlowing) {

            if(!isJumping) {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            } else if (doubleJump) {
                rig.AddForce(new Vector2(0f, JumpForce * 2f), ForceMode2D.Impulse);
                doubleJump = false;
                
            }  
        }
    }

    void OnCollisionEnter2D(Collision2D colisor) {
        if(colisor.gameObject.layer == 8) {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if(colisor.gameObject.tag == "Spike") {
            Controller.instance.ShowGameOver(); //Quando cair no espinho, chama o metodo game over
            Destroy(gameObject); //Desruir o gameObject Player quando cair no espinho
        }

        if(colisor.gameObject.tag == "Saw") {
            Controller.instance.ShowGameOver(); //Quando bater na serra, chama o metodo game over
            Destroy(gameObject); //Desruir o gameObject Player quando bater na serra
        }

        if(colisor.gameObject.tag == "NextLevel") {
            Controller.instance.ShowContinue();
        }
    }

    void OnCollisionExit2D(Collision2D colisor) {
        if(colisor.gameObject.layer == 8) {
            isJumping =  true;
        }
    }

    private void OnTriggerStay2D(Collider2D colisor) { //stay quando estiver em constante colisão com alguma coisa
        if(colisor.gameObject.layer == 11) {
            isBlowing =true;
        }
    }

    private void OnTriggerExit2D(Collider2D colisor) { //stay quando estiver em constante colisão com alguma coisa
        if(colisor.gameObject.layer == 11) {
            isBlowing =false;
        }
    }

}
