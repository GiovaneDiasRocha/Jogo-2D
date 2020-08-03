using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Biblioteca para manipular os elementos UI do jogo
using UnityEngine.SceneManagement; //Biblioteca para manipular as Scenes

public class Controller : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;
    public static Controller instance;
    public GameObject gameOver;
    public GameObject continueOrRestart;
    void Start()
    {
        instance = this; //Atribui o script na variável instance, para ser acessado de outro script através do método static
    }

    public void UpdateScoreText() { //Atualizar o totalScore na tela.
        scoreText.text = totalScore.ToString().PadLeft(4, '0'); //PadLeft formata o texto totalScore
    }

    public void ShowGameOver() { //Mostrar Game Over na tela
        gameOver.SetActive(true); //Ativa um GameObject na Scene
    }

    public void RestartGame(string lvlName) { //parametro está sendo usado para reiniciar a fase sem voltar pra fase inicial, é necessario referenciar Controller ao botão restart para passar o parametro
        SceneManager.LoadScene(lvlName);
    }

    public void ShowContinue() {
        continueOrRestart.SetActive(true);
    }

    public void ContinueGame(string nextLvl) {
        SceneManager.LoadScene(nextLvl);
    }

}
