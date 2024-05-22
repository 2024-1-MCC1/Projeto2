using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlaMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("game");//aqui faz com que a tela "game" seja carregada
    }

    public void QuitGame()
    {
        Application.Quit(); //aqui faz com que o jogo seja fechado
    }

    public void HistoryGame()
    {
        SceneManager.LoadScene("History");//aqui faz com que a tela "History" seja carregada
    }
}
