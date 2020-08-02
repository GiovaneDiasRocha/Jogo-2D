using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public GameObject collected;
    public int Score;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D colisor) { //Detectar se o personagem colidiu com o item/ isTrigger tem que estar marcado no componente de colisão
        if(colisor.gameObject.tag == "Player") {
            sr.enabled = false;        //Desativar o componente SpriteRenderer
            circle.enabled = false;    //Desativar o componente CircleCollider2D
            collected.SetActive(true); //Ativar o efeito de fumaça quando a fruta for coletada
            Controller.instance.totalScore += Score; //Soma o score da maçã ao scoreTotal, através do script GameController
            Controller.instance.UpdateScoreText(); //Atualizar Score total na tela

            Destroy(gameObject, 0.25f);   //Destroi a maçã depois de 1 segundo
        }
    }
}
