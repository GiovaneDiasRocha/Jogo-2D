using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //Movimenta no eixo X
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f){ //Testa o valor da variável do animator
            anim.SetBool("walk", true); 
            transform.eulerAngles = new Vector3(0f, 0f, 0f); //rotação do personagem quando vira pra direita
        }

        if(Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f); //rotação do personagem quando vira pra esquerda
        }

        if(Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("walk", false);
        }
    }

    void Jump() {
        if (Input.GetButtonDown("Jump")) {

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
    }

    void OnCollisionExit2D(Collision2D colisor) {
        if(colisor.gameObject.layer == 8) {
            isJumping =  true;
        }
    }

}
