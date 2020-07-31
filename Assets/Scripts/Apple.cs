using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colisor) { //Detectar se o personagem colidiu com o item/ isTrigger tem que estar marcado no componente de colisão
        if(GetComponent<Collider>().gameObject.tag == "Player") {

        }
    }
}
