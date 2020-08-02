using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importar biblioteca para manipular os elementos UI do jogo

public class Controller : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;
    public static Controller instance;
    void Start()
    {
        instance = this; //Atribui o script na variável instance, para ser acessado de outro script através do método static
    }

    public void UpdateScoreText() { //Atualizar o totalScore na tela.
        scoreText.text = totalScore.ToString().PadLeft(4, '0'); //PadLeft formata o texto totalScore
    }

}
