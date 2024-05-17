using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlaMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
