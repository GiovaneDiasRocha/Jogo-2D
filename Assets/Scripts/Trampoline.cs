using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    public float jumpForce;
    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D colisor) {

        anim.SetTrigger("jump"); //Executar a animação quando usar o trampolim

        if(colisor.gameObject.tag == "Player") { //tem que ter a tag player no gameObject Player
            colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
