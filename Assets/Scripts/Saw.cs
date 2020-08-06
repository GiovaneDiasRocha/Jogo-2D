using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    public float Speed;
    public float MoveTime;
    private bool DirectionSaw = true; // = true, para a serra começar indo pra direita
    private float Timer;
    void Update()
    {
        if(DirectionSaw) {
            transform.Translate(Vector2.right * Speed * Time.deltaTime); //Muda a direção da serra para a direita se valor bool for true
        } else {
            transform.Translate(Vector2.left * Speed * Time.deltaTime); //Muda a direção da serra para a esquerda se valor bool for false
        }

        Timer += Time.deltaTime; //incrementa tempo na variavel Time

        if(Timer >= MoveTime) { //para determinar o tempo na qual a serra vai mudar de direção
            DirectionSaw = !DirectionSaw; //Muda a direção da serra mudando o valor booleano para false
            Timer = 0f;
        }
    }
}
